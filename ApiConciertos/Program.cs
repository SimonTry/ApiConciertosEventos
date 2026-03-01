using ApiConciertos.DAO;
using ApiConciertos.Interfaces;
using ApiConciertos.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Extraemos del archivo appsettings.json la cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Le pasas las opciones de configuración al constructor de ApplicationDbContext que hereda las propiedades de DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddScoped<IEventosService, EventosService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Agregamos la inicialización de Scalar (Documentación)
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
