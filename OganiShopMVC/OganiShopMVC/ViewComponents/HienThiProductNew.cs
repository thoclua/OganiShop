using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiProductNew : ViewComponent
    {
        private ApplicationDbContext _db;
        public HienThiProductNew(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            DateTime endDate = DateTime.Now; // Thời điểm hiện tại
            DateTime startDate = endDate.AddDays(-10); // Trừ 10 ngày từ thời điểm hiện tại

            var productsInTimeRange = _db.Products
                .Where(p => p.CreatedDate >= startDate && p.CreatedDate <= endDate).Take(3)
                .ToList();
            return View( productsInTimeRange);
        }
    }
}
