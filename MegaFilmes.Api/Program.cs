using MegaFilmes.Api.Services;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using MegaFilmes.Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
var connectionString = builder.Configuration.GetConnectionString("MegaFilmesConnection");
builder.Services.AddEntityFrameworkSqlServer()
.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Repositories
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

// Services
builder.Services.AddScoped<IFilmeService, FilmeService>();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
