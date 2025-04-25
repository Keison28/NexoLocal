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

builder.Services.AddControllersWithViews();


// Registrar controladores
builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<OrdenRepository>();
builder.Services.AddScoped<OrdenService>();





builder.Services.AddHttpClient("PedidosAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7145/"); // <-- cambia esto por la URL real de tu API
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
