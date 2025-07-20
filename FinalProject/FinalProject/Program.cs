using BL;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.DTO;
<<<<<<< HEAD
using DAL.Models.models;
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> 9fb314763b70246f3b61e943659718d0e9af02a9

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
<<<<<<< HEAD

// AutoMapper configuration and registration
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
    cfg.AddProfile<APIMappingProfile>();
=======
// Register AutoMapper and scan for profiles in the BL assembly
var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
    cfg.AddProfile<ApiMappingProfile>();
>>>>>>> 9fb314763b70246f3b61e943659718d0e9af02a9
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

<<<<<<< HEAD
// Register DbContext with Scoped lifetime (recommended)
builder.Services.AddDbContext<dbClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register DalManager and BlManager as Scoped, and pass dependencies via constructor
builder.Services.AddScoped<IDalManager, DalManager>();
builder.Services.AddScoped<IBlManager, BlManager>();

=======
//builder.Services.AddSingleton<IDalManager, DalManager>();
builder.Services.AddSingleton<IBlManager, BlManager>();
>>>>>>> 9fb314763b70246f3b61e943659718d0e9af02a9
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();  // <-- Add authentication middleware here
app.UseAuthorization();

app.MapControllers();

app.Run();