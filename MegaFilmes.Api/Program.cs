using MegaFilmes.Api.Services;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using MegaFilmes.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Remove null results
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// DbContext
var connectionString = builder.Configuration.GetConnectionString("MegaFilmesConnection");
builder.Services.AddEntityFrameworkSqlServer()
.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Repositories
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IAtorRepository, AtorRepository>();
builder.Services.AddScoped<IFilmeAtorRepository, FilmeAtorRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

// Services
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IAtorService, AtorService>();
builder.Services.AddScoped<IFilmeAtorService, FilmeAtorService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Insere no banco automaticamente
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate(); // Rode o update database
    SeedData.Initialize(context); // Faz o seed de dados
}

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
