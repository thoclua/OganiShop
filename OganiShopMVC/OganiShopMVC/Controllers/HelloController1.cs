using Microsoft.AspNetCore.Mvc;

namespace OganiShopMVC.Controllers
{
    public class HelloController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
