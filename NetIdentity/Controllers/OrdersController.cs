using Microsoft.AspNetCore.Mvc;
using NetIdentity.Data;
using NetIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace NetIdentity.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrdersController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var orders = await _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();
            return View(orders);
        }
    }
}
