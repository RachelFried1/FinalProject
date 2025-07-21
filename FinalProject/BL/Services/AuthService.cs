using AutoMapper;
using BL.Api;
using BL.Models;
using DAL.Exceptions;
using DAL.Models.models;
using DAL;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService :IAuth
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
        jobSeekerEntity.Password = new JobSeekerPassword
        {
            PasswordHash = passwordHash,
            JobSeekerId = seeker.Id
        };
        _dalManager.JobSeekerManager.AddJobSeeker(jobSeekerEntity);
    }

    public void SignUpCompany(CompanyBL company, string password)
    {
        if (_dalManager.CompanyManager.GetCompanyById(company.Code) != null)
            throw new CompanyAlreadyExistsException(company.Code);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var companyEntity = _mapper.Map<Company>(company);
        companyEntity.Password = new CompanyPassword
        {
            PasswordHash = passwordHash,
            CompanyId = company.Code
        };
        _dalManager.CompanyManager.AddCompany(companyEntity);
    }

    public string SignInJobSeeker(string email, string password)
    {
        var jobSeeker = _dalManager.JobSeekerManager.GetJobSeekerByEmail(email);
        if (jobSeeker != null && jobSeeker.Password != null &&
            BCrypt.Net.BCrypt.Verify(password, jobSeeker.Password.PasswordHash))
        {
            return GenerateJwtToken(email, "JobSeeker");
        }
        throw new ArgumentException("Invalid email or password.");
    }

    public string SignInCompany(string email, string password)
    {
        var company = _dalManager.CompanyManager.GetCompanyByEmail(email);
        if (company != null && company.Password != null &&
            BCrypt.Net.BCrypt.Verify(password, company.Password.PasswordHash))
        {
            return GenerateJwtToken(email, "Company");
        }
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
