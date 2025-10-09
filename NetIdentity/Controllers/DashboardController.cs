using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetIdentity.Data;
using Microsoft.EntityFrameworkCore;

namespace NetIdentity.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var usersCount = await _db.Users.CountAsync();
            var productsCount = await _db.Products.CountAsync();
            var ordersCount = await _db.Orders.CountAsync();
            var recentOrders = await _db.Orders
                .OrderByDescending(o => o.CreatedAt)
                .Include(o => o.Items)
                .Take(5).ToListAsync();

            ViewData["UsersCount"] = usersCount;
            ViewData["ProductsCount"] = productsCount;
            ViewData["OrdersCount"] = ordersCount;
            ViewData["RecentOrders"] = recentOrders;

            return View();
        }
    }
}
