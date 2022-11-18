using EFDemo3.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFDemo3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {

            BrightDb2Context db = new BrightDb2Context();

            List<Product> products = db.Products.ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            BrightDb2Context db = new BrightDb2Context();
              db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            BrightDb2Context db = new BrightDb2Context();
            var product = db.Products.FirstOrDefault(x => x.Id == id);  
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {

            BrightDb2Context db = new BrightDb2Context();
            var productToUpdte = db.Products.FirstOrDefault(x => x.Id == product.Id);

            productToUpdte.Name = product.Name;
            productToUpdte.CagtegoryName = product.CagtegoryName;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            BrightDb2Context db = new BrightDb2Context();
            var product = db.Products.FirstOrDefault(x=>x.Id== id);
            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
