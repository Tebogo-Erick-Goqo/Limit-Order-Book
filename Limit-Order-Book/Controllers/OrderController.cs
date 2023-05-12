using Limit_Order_Book.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Limit_Order_Book.Controllers
{
    [Route("orders")]
    public class OrderController : Controller
    {
        private readonly DatabaseContxt db;

        public OrderController(DatabaseContxt _db)
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

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Orders());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Orders.Remove(db.Orders.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var order = db.Orders.Find(id);
            return View("Edit", order);
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
