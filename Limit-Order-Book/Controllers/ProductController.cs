using Limit_Order_Book.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Limit_Order_Book.Controllers
{
    [Route("orders")]
    public class ProductController : Controller
    {
        private readonly DatabaseContxt db;

        public ProductController(DatabaseContxt _db)
        {
            db = _db;
        }

            [Route("")]
            [Route("~/")]
            [Route("index")]
        public IActionResult Index()
        {
            ViewBag.orders = db.Orders.ToList();
            return View();
        }
    }
}
