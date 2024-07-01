using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Entities;
using Proje_OOP.ProjectContext;

namespace Proje_OOP.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (customer.Name.Length >= 6 && customer.City != "" && customer.City.Length >= 3)
            {
                context.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Hatalı Kullanım";
                return View();
            }
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value=context.Customers.Where(x=>x.Id==id).FirstOrDefault(); 
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (customer.Name.Length >= 6 && customer.City != "" && customer.City.Length >= 3)
            {
                var value = context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
                value.City = customer.City;
                value.Name = customer.Name;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
