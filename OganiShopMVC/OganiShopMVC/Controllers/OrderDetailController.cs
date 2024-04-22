using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;
using OganiShopMVC.Repository;

namespace OganiShopMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
