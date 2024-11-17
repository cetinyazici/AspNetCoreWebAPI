using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.ViewComponents
{
    public class PersonellerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
