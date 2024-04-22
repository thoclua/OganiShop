using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiProductByCategoryId : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiProductByCategoryId(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var item = _db.Products.Take(12).ToList();

            return View(item);
        }
    }
}
