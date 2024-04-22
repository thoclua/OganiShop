
using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Infrastructure;
using OganiShopMVC.Models;
using OganiShopMVC.Models.ViewModels;
using OganiShopMVC.Repository;
using Umbraco.Core.Configuration.UmbracoSettings;

namespace OganiShopMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
       public ShoppingCart? ShoppingCart { get; set; }
        private ApplicationDbContext _db;
        public ShoppingCartController(ApplicationDbContext context )
        {
            _db = context;
            
        }
        public IActionResult Index()
        {
           
            return View("Cart", HttpContext.Session.GetJson<ShoppingCart>("Cart"));
        }

        public IActionResult AddToCart(int productId)
        {
            Product? product = _db.Products.FirstOrDefault(p=>p.id== productId);
            if (product != null)
            {
                ShoppingCart = HttpContext.Session.GetJson<ShoppingCart>("Cart") ?? new ShoppingCart();
                ShoppingCart.AddItem(product,1);
                HttpContext.Session.SetJson("Cart", ShoppingCart);
            }
            return View("Cart",ShoppingCart);
        }
        public IActionResult DeleteQuantityCart(int productId)
        {
            Product? product = _db.Products.FirstOrDefault(p => p.id == productId);
            if (product != null)
            {
                ShoppingCart = HttpContext.Session.GetJson<ShoppingCart>("Cart") ?? new ShoppingCart();
                ShoppingCart.AddItem(product, -1);
                HttpContext.Session.SetJson("Cart", ShoppingCart);
            }
            return View("Cart", ShoppingCart);
        }

        public IActionResult ReMove(int productId)
        {
            Product? product = _db.Products.FirstOrDefault(p => p.id == productId);
            if (product != null)
            {
                ShoppingCart = HttpContext.Session.GetJson<ShoppingCart>("Cart");
                ShoppingCart.RemoveItem(product);
                HttpContext.Session.SetJson("Cart", ShoppingCart);
            }
            return View("Cart",ShoppingCart);

        }

        



    }
       

 }

