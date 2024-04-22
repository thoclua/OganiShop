using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Infrastructure;
using OganiShopMVC.Models;

namespace OganiShopMVC.ViewComponents
{
    public class Cart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            return View(HttpContext.Session.GetJson<ShoppingCart>("Cart"));
        }

    }
}
