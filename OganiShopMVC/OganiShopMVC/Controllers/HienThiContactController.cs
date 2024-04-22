using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;

namespace OganiShopMVC.Controllers
{
    public class HienThiContactController : Controller
    {
        private ApplicationDbContext _db;
        public HienThiContactController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var item = _db.Configs.ToList();
            return View(item);
        }
    }
}
