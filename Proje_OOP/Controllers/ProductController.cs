using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Entities;
using Proje_OOP.ProjectContext;

namespace Proje_OOP.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Where(x=> x.Id == id).FirstOrDefault();
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = context.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            value.Name = product.Name;
            value.Price = product.Price;
            value.Stock = product.Stock;
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }


    }
}
