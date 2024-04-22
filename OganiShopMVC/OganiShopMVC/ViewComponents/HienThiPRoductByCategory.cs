using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.ViewComponents
{
    public class HienThiPRoductByCategory : ViewComponent
    {
        private ApplicationDbContext _db;

        public HienThiPRoductByCategory(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke(int Id)
        {

            var items = _db.Categorys.ToList();
           
           
            return View(items);
        }
    }
}
