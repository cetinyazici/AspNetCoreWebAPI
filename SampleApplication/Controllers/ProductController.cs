using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApplication.Models;
using SampleApplication.Models.ViewModels;
using System.Reflection;
using System.Text.Json;

namespace SampleApplication.Controllers
{
    //[NonController]
    public class ProductController : Controller
    {
        #region ViewResult
        public ViewResult GetProducts()
        {
            ViewResult result = View();
            return result;
        }
        #endregion
        #region PartialViewResult
        public PartialViewResult GetProduct()
        {
            PartialViewResult result = PartialView();
            return result;
        }
        #endregion
        #region JsonResult
        public JsonResult GetProductsJson()
        {
            JsonResult result = Json(new Product { Id = 1, Name = "ProductName", Description = "Description" });
            return result;
        }
        #endregion
        #region EmptyResult
        public EmptyResult GetProductsEmpty()
        {
            return new EmptyResult();
        }
        #endregion
        #region ContentResult
        public ContentResult GetProductsContent()
        {
            ContentResult result = Content("Metinsel bir değer...");
            return result;
        }
        #endregion
        #region ActionResult
        public ActionResult GetProductsAction()
        {
            if (true)
            {
                return Json(new object());
            }
            else if (true)
            {
                return Content("Metinsel Değer....");
            }
            return View();
        }
        #endregion
        #region NonAction 
        public IActionResult Index()
        {
            X();
            return View();
        }
        [NonAction]
        public void X()
        {
            //işlemler
        }
        #endregion
        #region Model, ViewBag, ViewData, TempData
        public IActionResult Index1()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1,Name="Name1",Description="Description1" },
                new Product { Id = 2,Name="Name2",Description="Description2" },
                new Product { Id = 3,Name="Name3",Description="Description3" },
            };
            ViewBag.products = products;
            ViewData["products"] = products;

            var data = JsonConvert.SerializeObject(products);
            TempData["productsTempData"] = data;

            ViewBag.x = 5;
            ViewData["x"] = 5;
            TempData["x"] = 5;

            return RedirectToAction("Index2", "Product");
        }

        public IActionResult Index2()
        {
            var data = TempData["productsTempData"].ToString();
            JsonConvert.DeserializeObject<List<Product>>(data);
            var v1 = ViewBag.x;
            var v2 = ViewData["x"];
            var v3 = TempData["x"];
            return View();
        }
        #endregion
        #region Tuple
        public IActionResult GetProductAndUser()
        {
            Product product = new Product();
            product.Id = 1;
            product.Name = "ProductName";
            product.Description = "ProductDescription";

            User user = new User();
            user.Id = 1;
            user.UserName = "UserName";
            user.UserSurname = "UserSurname";

            //ProductUser productUser = new ProductUser();
            //productUser.Product = product;
            //productUser.User = user;

            var productUser = (product, user);

            //return View(productUser);
            return View(productUser);
        }
        #endregion
        #region Model Binding
        public IActionResult CreateProduct()
        {
            var product = new Product();
            product.Id = 1;
            product.Name = "Deneme";
            product.Description = "Deneme";
            return View(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return View();
        }
        #endregion
    }
}

