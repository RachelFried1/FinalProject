using BL;
using DAL;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>

    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("YourSuperSecretKey"))
        };
    });

builder.Services.AddAuthorization();

// Register AutoMapper and scan for profiles in the BL assembly
var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

IMapper mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddSingleton<IDalManager, DalManager>();
builder.Services.AddSingleton<IBlManager, BlManager>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseExceptionHandler("/error"); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
