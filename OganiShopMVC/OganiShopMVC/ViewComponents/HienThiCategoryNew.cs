using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiCategoryNew : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiCategoryNew(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var item = _db.CategoryNews.ToList();
            return View(item);
        }
    }
}
