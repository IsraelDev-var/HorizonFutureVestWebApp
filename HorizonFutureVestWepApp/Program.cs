using Application.Services;
using Application.Services.Interface;
using Application.Validations;
using Application.Validations.Inteface;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositpries;
using Persistence.Repositpries.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configuracion de la coneccion a la base de datos
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppContextDB>(opt => { opt.UseSqlServer(connectionString); });

// Configuración de la conexión a MySQL
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<AppContextDB>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Registro de repositorios e inyección de dependencias

// Country
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
// macro indicador
builder.Services.AddScoped<IMacroindicatorRepository, MacroindicatorRepository>();
builder.Services.AddScoped<IMacroindicatorService, MacroindicatorService>();
builder.Services.AddScoped<IWeightValidation, TotalWeightValidation>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
