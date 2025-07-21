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
    private readonly string _jwtSecret = "YourSuperSecretKeyThatIsAtLeast32Chars!";
    private readonly int _jwtExpirationMinutes = 60;

    private IMapper _mapper;
    IDalManager _dalManager;

    public AuthService(IMapper mapper, IDalManager dalManager)
    {
        _dalManager = dalManager;
        _mapper = mapper;
    }

    public string SignUpJobSeeker(JobSeekerBL seeker, string password)
    {
        if (_dalManager.JobSeekerManager.GetJobSeekerById(seeker.Id) != null)
            throw new SeekerAlreadyExistsException(seeker.Id);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        var jobSeekerEntity = _mapper.Map<JobSeeker>(seeker);

        jobSeekerEntity.UserPassword = new JobSeekerPassword
        {
            JobSeekerId = seeker.Id,
            PasswordHash = passwordHash
        };
        _dalManager.JobSeekerManager.AddJobSeeker(jobSeekerEntity);
        return GenerateJwtToken(seeker.Id, seeker.Email, "JobSeeker");
    }

    public string SignUpCompany(CompanyBL company, string password)
    {
        if (_dalManager.CompanyManager.GetCompanyById(company.Code) != null)
            throw new CompanyAlreadyExistsException(company.Code);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var companyEntity = _mapper.Map<Company>(company);

        companyEntity.UserPassword = new CompanyPassword
        {
            CompanyId = company.Code,
            PasswordHash = passwordHash
        };
        _dalManager.CompanyManager.AddCompany(companyEntity);
        return GenerateJwtToken(company.Code, company.Email, "Company");
    }

    public string SignInJobSeeker(string email, string password)
    {
        var jobSeeker = _dalManager.JobSeekerManager.GetJobSeekerByEmail(email);

        if (jobSeeker != null && jobSeeker.UserPassword != null &&
            BCrypt.Net.BCrypt.Verify(password, jobSeeker.UserPassword.PasswordHash))

        {
            return GenerateJwtToken(jobSeeker.Id, email, "JobSeeker");
        }
        throw new ArgumentException("Invalid email or password.");
    }

    public string SignInCompany(string email, string password)
    {
        var company = _dalManager.CompanyManager.GetCompanyByEmail(email);

        if (company != null && company.UserPassword != null &&
            BCrypt.Net.BCrypt.Verify(password, company.UserPassword.PasswordHash))
        {
            return GenerateJwtToken(company.Code, email, "Company");
        }
        throw new ArgumentException("Invalid email or password.");
    }

    private string GenerateJwtToken(int id, string email, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
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