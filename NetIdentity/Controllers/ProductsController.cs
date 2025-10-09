using Microsoft.AspNetCore.Mvc;
using NetIdentity.Data;
using NetIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace NetIdentity.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }
    }
}
