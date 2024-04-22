using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiProduct : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiProduct(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IViewComponentResult Invoke()
        {
            var item = _db.Products.Take(3).ToList();
            return View(item);
        }


    }
}
