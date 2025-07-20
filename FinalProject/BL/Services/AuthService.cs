using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using AutoMapper;
using DAL;
using BL.Models;
using DAL.Exceptions;
using DAL.Models.models;
using DAL.Api;
using BL.Api;

public class AuthService:IAuth
{
    private readonly string _jwtSecret = "YourSuperSecretKey"; 
    private readonly int _jwtExpirationMinutes = 60;

    private IMapper _mapper;
    IDalManager _dalManager;

    public AuthService(IMapper mapper, IDalManager dalManager)
    {
        _dalManager = dalManager;
        _mapper = mapper;
    }

    
    public void SignUpJobSeeker(JobSeekerBL seeker, string password)
    {
        if (_dalManager.JobSeekerManager.GetJobSeekerById(seeker.Id) != null)
            throw new SeekerAlreadyExistsException(seeker.Id);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        var jobSeekerEntity = _mapper.Map<JobSeeker>(seeker);
        jobSeekerEntity.UserPassword = new UserPassword
        {
            UserType = "JobSeeker",
            PasswordHash = passwordHash,
            UserId = seeker.Id 
        };
        _dalManager.JobSeekerManager.AddJobSeeker(jobSeekerEntity);
    }

   
    public void SignUpCompany(CompanyBL company, string password)
    {
        if (_dalManager.CompanyManager.GetCompanyById(company.Code) != null)
            throw new CompanyAlreadyExistsException(company.Code);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var companyEntity = _mapper.Map<Company>(company);
        companyEntity.UserPassword = new UserPassword
        {
            UserType = "Company",
            PasswordHash = passwordHash,
            UserId = company.Code
        };
        _dalManager.CompanyManager.AddCompany(companyEntity);
    }

    public string SignIn(string email, string password)
    {
        var jobSeeker = _dalManager.JobSeekerManager.GetJobSeekerByEmail(email);
        if (jobSeeker != null && BCrypt.Net.BCrypt.Verify(password, jobSeeker.UserPassword.PasswordHash))
            return GenerateJwtToken(email, "JobSeeker");

        var company = _dalManager.CompanyManager.GetCompanyByEmail(email);
        if (company != null && BCrypt.Net.BCrypt.Verify(password, company.UserPassword.PasswordHash))
            return GenerateJwtToken(email, "Company");

        throw new ArgumentException("Invalid email or password.");
    }

    private string GenerateJwtToken(string email, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtExpirationMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
