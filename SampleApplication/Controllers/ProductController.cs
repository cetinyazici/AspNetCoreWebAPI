using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    [NonController]
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
    }
}
