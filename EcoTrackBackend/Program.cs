using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EcoTrack;
using EcoTrack.Models;
using EcoTrackBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "https://ecotrackprueba.vercel.app/","ecotrackunab-edebdwczaefhb7fz.centralus-01.azurewebsites.net")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials(); // Permite credenciales
        });
});

// Configuración de Entity Framework y servicios
builder.Services.AddDbContext<EcoTrackDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("EcoTrackDbContext"),
        new MySqlServerVersion(new Version(8, 0, 25))
    ));

// Registro de servicios
builder.Services.AddHttpClient<ApiService>();
builder.Services.AddTransient<WeatherService>();
builder.Services.AddHostedService<NotificacionService>();


// Agregar SignalR
builder.Services.AddSignalR();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcoTrack API", Version = "v1" });
});

// Configura la URL de la aplicación
builder.WebHost.UseUrls("http://localhost:5000");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAllOrigins"); // Asegúrate de que esté antes de UseAuthorization
app.UseAuthorization();
app.MapControllers(); // Asegúrate de que los controladores están mapeados


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoTrack API v1"));

app.Run();
