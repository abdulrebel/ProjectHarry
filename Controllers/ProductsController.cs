using Microsoft.AspNetCore.Mvc;
using Qhrm.Models;

namespace Qhrm.Controllers
{
    public class ProductsController : Controller
    {
        private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=MVCDapperDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: /Product
        public IActionResult Index()
        {
            IEnumerable<ProductsModel> products = DapperORM.GetAllProducts(connectionString);
            return View(products);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductsModel product)
        {
            if (ModelState.IsValid)
            {
                
                DapperORM.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

       // GET: /Product/Edit/5
        public IActionResult Edit(int id)
        {
            ProductsModel product = DapperORM.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        } 

        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductsModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                DapperORM.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: /Product/Delete/5
        public IActionResult Delete(int id)
        {
            ProductsModel product = DapperORM.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        /* [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            DapperORM.DeleteProduct(id);
            return RedirectToAction("Index");
        } */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProductsModel product = DapperORM.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            DapperORM.DeleteProduct(id);
            return RedirectToAction("Index");
        }


    }
}
