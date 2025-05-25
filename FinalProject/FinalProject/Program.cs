using BL;
using DAL;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
AppDomain.CurrentDomain.SetData("DataDirectory", AppContext.BaseDirectory);

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

app.UseExceptionHandler("/error"); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
