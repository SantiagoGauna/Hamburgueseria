using BLL;
using DAO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("HamburgueseriaConnection");

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddDbContext<Hamburgueseria>(options =>
    options.UseSqlServer(connectionString));

// Agregar tu BLL como servicio
builder.Services.AddScoped<ClienteBLL>();
builder.Services.AddScoped<HamburguesaBLL>();
builder.Services.AddScoped<PedidoBLL>();

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Habilitar CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.MapControllers();

app.Run();
