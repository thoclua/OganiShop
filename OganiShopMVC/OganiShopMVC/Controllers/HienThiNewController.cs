using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.Controllers
{
    public class HienThiNewController : Controller
    {
        private ApplicationDbContext _db;
        public HienThiNewController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var item = _db.News.ToList();
            return View(item);
        }
        public IActionResult Detail(int id)
        {
            var item = _db.News.Find(id);
           
            return View(item);
        }
    }
}
