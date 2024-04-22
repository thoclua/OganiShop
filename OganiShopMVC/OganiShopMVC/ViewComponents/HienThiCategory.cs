using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiCategory : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiCategory(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var item = _db.Categorys.ToList();
            return View(item);
        }
    }
}
