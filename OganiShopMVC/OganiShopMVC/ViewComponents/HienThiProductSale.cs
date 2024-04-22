using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiProductSale : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiProductSale(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var saleProducts = _db.Products.Where(item => item.Sale == true).Take(3).ToList();


            return View(saleProducts);
        }
    }
}
