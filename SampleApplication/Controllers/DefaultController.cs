using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var tuple = (new Product(), new User());
            return View(tuple);
        }
        [HttpPost]
        public IActionResult Index([Bind(Prefix = "Item1")] Product product, [Bind(Prefix = "Item2")] User user)
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.ErrorMessage = ModelState.Values.FirstOrDefault(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
                var message = ModelState.ToList();
                var images = new List<string> { "dfghj", "dfghj", "cvbnkl" };
                ViewBag.Data = "dfghjklş";
                return View(images);
            }
            return View();
        }
    }
}
