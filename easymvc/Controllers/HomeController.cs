using Entities;
using Microsoft.AspNetCore.Mvc;
using DatabaseConfiger;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DatabaseBussines;
namespace easymvc.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext context;

        public HomeController(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var ordertable= context.OrderTable.ToList();
            var orderitemtable = context.OrderItemTable.ToList();
            ViewBag.OrderTable = ordertable;
            ViewBag.OrderItemTable = orderitemtable;

            return View();
        }
        public IActionResult OrderAdding()
        {

            return View();
        }
        public IActionResult OrderItemadding()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OrderItemadding(OrderItem item)
        {
            OrderItemBussines bussines = new OrderItemBussines(context);
            bool check=bussines.Add(item);
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View("Hatali");

        }
        public IActionResult OrderItemAddingUpdate(int id)
        {
            OrderItem order = context.OrderItemTable.Find(id);

            return View(order);

        }
        [HttpPost]
        public IActionResult OrderItemAddingUpdate(OrderItem order)
        {
            OrderItemBussines bussines = new OrderItemBussines(context);
            bool check = bussines.Update(order);
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View("Hatali");

        }
        public IActionResult OrderItemAddingDelete(int id)
        {
            OrderItemBussines bussines = new OrderItemBussines(context);
            bool check = bussines.Delete(id);
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View("Hatali");

        }
        [HttpPost]
        public IActionResult OrderAdding(Order order)
        {
           EntityEntry entry= context.Add(order);
            if (entry.State==Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("i wish");

        }
        public IActionResult OrderAddingUpdate(int id)
        {
            Order order=context.OrderTable.Find(id);

            return View(order);

        }
        [HttpPost]
        public IActionResult OrderAddingUpdate(Order order)
        {
            OrderBussines bussines = new OrderBussines(context);
            bool check=bussines.Update(order);
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View("Hatali");

        }
        public IActionResult OrderAddingDelete(int id)
        {
            OrderBussines bussines = new OrderBussines(context);
            bool check = bussines.Delete(id);
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View("Hatali");

        }
    }
}
