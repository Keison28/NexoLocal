using System.Diagnostics;
using Marketplace.Infrastructure.Context;
using MarketPlace.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Frontend.Controllers
{
    public class HomeController : Controller
    {

        private readonly MarketplaceDbContext _context;

        public HomeController(MarketplaceDbContext context)
        {
            _context = context;
        }
       

        public async Task<IActionResult> Catalogo()
        {
            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
