using Marketplace.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductoRepository>();  // Usamos IProductoRepository como la interfaz

builder.Services.AddScoped<ProductoService>(); // O usa AddTransient o AddSingleton según corresponda

// Configura la conexión a la base de datos y los servicios necesarios
builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabaseStr")));

builder.Services.AddControllersWithViews();


// Registrar controladores
builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ProductoRepository>();

// Configura HttpClient para hacer peticiones al backend de la API
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7145;http://localhost:5266"); // La URL de la API, ajústala si es diferente
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configura el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
