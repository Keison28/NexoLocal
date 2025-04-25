using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

public class PedidosController : Controller
{
    private readonly HttpClient _httpClient;

    public PedidosController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("PedidosAPI");
    }

    public async Task<IActionResult> Index()
    {
        var pedidos = await _httpClient.GetFromJsonAsync<List<Pedido>>("api/pedidos");
        return View(pedidos);
    }
}
