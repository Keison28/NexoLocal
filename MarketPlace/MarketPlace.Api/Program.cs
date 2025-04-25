using Marketplace.Application.Interfaces;
using Marketplace.Application.Services;
using Marketplace.Infrastructure.Context;
using Marketplace.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductoRepository>();  // Usamos IProductoRepository como la interfaz

builder.Services.AddScoped<ProductoService>(); // O usa AddTransient o AddSingleton según corresponda

// Configura la conexión a la base de datos y los servicios necesarios
builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabaseStr")));

// Registrar controladores
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<OrdenRepository>();
builder.Services.AddScoped<OrdenService>();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);



var app = builder.Build();

// Configuración para Swagger (si estás usando Swagger)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();



// Configura HttpClient para hacer peticiones al backend de la API
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7145;http://localhost:5266"); // La URL de la API, ajústala si es diferente
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Configura los servicios MVC
builder.Services.AddControllersWithViews();


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
