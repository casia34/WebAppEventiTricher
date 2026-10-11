using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppdbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173","https://localhost:5173"));

app.MapControllers();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{   
    var context = services.GetRequiredService<AppdbContext>();
    await context.Database.MigrateAsync();
    await DbInizializer.SeedData(context);
}
catch (Exception ex) {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger. LogError(ex, "An error occurred during migration.");
}
app.Run();

