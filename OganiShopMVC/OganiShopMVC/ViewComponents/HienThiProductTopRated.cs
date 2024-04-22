using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiProductTopRated : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiProductTopRated(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var TopRatedProducts = _db.Products.Where(item => item.Rating > 3).Take(3).ToList();

            return View(TopRatedProducts);
        }
    }
}
