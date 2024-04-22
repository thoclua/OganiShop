using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiSlider : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiSlider(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var selectedBanner = _db.Slides.Where(item => item.id == 1 || item.id == 2).ToList();
            return View(selectedBanner);
        }
    }
}
