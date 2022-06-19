using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oxxy.SelectiveProcess.Vehicle.Api.Config;
using Oxxy.SelectiveProcess.Vehicle.Api.Model.Context;
using Oxxy.SelectiveProcess.Vehicle.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Set connectionstring
var connetion = builder.Configuration["SQLServerConnection:SQLServerConnectionString"];
builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connetion));

// Add automapper configuration
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
