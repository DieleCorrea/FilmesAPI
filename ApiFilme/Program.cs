using ApiFilme.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
//conex�o com banco de dados 
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(opts => 
opts.UseMySql(builder.Configuration.GetConnectionString("FilmeConnection"), ServerVersion.AutoDetect(connectionString)));


//builder.Services.AddDbContext<FilmeContext>(opts =>
// opts.UseMySql(builder.Configuration.GetconnectionString("FilmeConnection"), ServerVersion.AutoDetect(connectionString));

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
