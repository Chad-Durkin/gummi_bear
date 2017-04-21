using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gummi_Bear.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gummi_Bear.Controllers
{
    public class ProductController : Controller
    {
        private GummiBearDbContext db = new GummiBearDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var ProductEdit = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(ProductEdit);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var ProductDelete = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(ProductDelete);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
