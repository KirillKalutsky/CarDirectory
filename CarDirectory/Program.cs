using CarDirectory.DB;
using CarDirectory.Services;
using CarDirectory.Models;
using CarDirectory.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cS = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
    "host=localhost;port=5432;database=automobiles;username=postgres;password=abrakadabra77";

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<AutomobileContext>(opt => opt.UseNpgsql(cS));

builder.Services.AddScoped<AutomobileContext>();
builder.Services.AddScoped<Repository<Automobile>, AutomobileRepository>();
builder.Services.AddScoped<IAutomobileService, AutomobileService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Prepare(app);

app.Run();


static void Prepare(IApplicationBuilder app)
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    using (var context = app.ApplicationServices.CreateScope())
    {
        var supportContext = context.ServiceProvider.GetService<AutomobileContext>();
        supportContext.Database.Migrate();
    }
}