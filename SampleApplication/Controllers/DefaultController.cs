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
        public IActionResult Index([Bind(Prefix ="Item1")]Product product, [Bind(Prefix = "Item2")]User user)
        {
            return View();
        }
    }
}
