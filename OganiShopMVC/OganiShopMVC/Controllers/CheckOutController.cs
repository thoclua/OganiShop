using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Infrastructure;
using OganiShopMVC.Models;
using System.Security.Claims;

namespace OganiShopMVC.Controllers
{
    public class CheckOutController : Controller
    {
        public ShoppingCart? ShoppingCart { get; set; }
        private ApplicationDbContext _db;
        public CheckOutController(ApplicationDbContext context)
        {
            _db = context;

        }
        public IActionResult Index()
        {
            return View( HttpContext.Session.GetJson<ShoppingCart>("Cart"));
        }
        public IActionResult CheckOut()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {


                var ordercode = Guid.NewGuid().ToString();
                var oderItem = new Order();
                oderItem.code = ordercode;
                oderItem.UserName = userEmail;
                oderItem.status = "đặt hàng";
                oderItem.CreatedDate = DateTime.Now;
                _db.Add(oderItem);
                _db.SaveChanges();
                ShoppingCart = HttpContext.Session.GetJson<ShoppingCart>("Cart") ?? new ShoppingCart();
                foreach (var item in ShoppingCart.Items)
                {
                    var oderdetails = new OrderDetail();
                    oderdetails.UserName = userEmail;
                    oderdetails.ProductId = item.id;
                    oderdetails.Price = item.Product.Price;
                    oderdetails.Quantity = (int)item.Quantity;
                    _db.SaveChanges();
                }
                TempData["success "] = "CheckOut thành công";
                return RedirectToAction("Index", "CheckOut");
            }

            
            return View();
        }
    }
}
