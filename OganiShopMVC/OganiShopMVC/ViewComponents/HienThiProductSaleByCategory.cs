using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiProductSaleByCategory : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiProductSaleByCategory(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var item = _db.Products.Where(item => item.Sale == true).Take(6).ToList();
            return View(item);
        }

    }
}
