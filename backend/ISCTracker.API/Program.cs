using DotNetEnv;
using ISCTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env.
Env.Load();

// Obtener la cadena de conexión a PostgreSQL.
// Si la variable no existe, detener el inicio y mostrar un mensaje.
var connectionString =
    Environment.GetEnvironmentVariable("ConnectionStrings__PostgresConnection")
    ?? throw new InvalidOperationException(
        "Falta la variable ConnectionStrings__PostgresConnection en el archivo .env.");

// Registrar el contexto de Entity Framework Core y los repositorios
// definidos en el proyecto Infrastructure.
builder.Services.AddInfrastructure(connectionString);

// Registrar los controladores que atenderán las solicitudes HTTP.
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Registrar los servicios necesarios para generar la documentación OpenAPI.
builder.Services.AddOpenApi();

var app = builder.Build();

// Habilitar el documento OpenAPI únicamente en el entorno de desarrollo.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Redirigir las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Habilitar las rutas definidas en los controladores.
app.MapControllers();

// Definir los posibles resúmenes del pronóstico meteorológico de ejemplo.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Crear el endpoint de ejemplo /weatherforecast.
// Genera cinco pronósticos con fechas y temperaturas aleatorias.
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    return forecast;
})
.WithName("GetWeatherForecast");

// Iniciar la aplicación y comenzar a recibir solicitudes.
app.Run();

// Definir la estructura de cada pronóstico meteorológico.
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    // Calcular la temperatura en Fahrenheit a partir de Celsius.
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}