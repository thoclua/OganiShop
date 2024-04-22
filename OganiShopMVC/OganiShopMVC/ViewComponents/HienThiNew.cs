using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiNew : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiNew(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var item = _db.News.Take(3).ToList();
            return View(item);
        }
    }
}
