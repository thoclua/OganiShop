using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Controllers
{
    public class HienThiClientController : Controller
    {
        private ApplicationDbContext _db;
        public HienThiClientController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    //    public IActionResult Product()
    //    {
    //        var products = _db.GetProducts.ToList();
    //        return View("_Product", products);
    //    }
    //    public IActionResult Category()
    //    {
    //        var item = _db.GetCategories.ToList();
    //        return View("_Category", item);
    //    }
    //    public ActionResult ProductByCategory(int Id)
    //    {

    //        var items = _db.GetProducts.ToList();
    //        if (Id > 0)
    //        {
    //            items = items.Where(p => p.CategoryId == Id).ToList();
    //        }
    //        return View("_ProductByCategory", items);
    //    }
    //    public IActionResult Banner()
    //    {
    //        slide selectedBanner = _db.GetBanners.Where(item => item.id == 1 || item.id == 2).FirstOrDefault() ?? new slide();
    //        return View("_Banner", selectedBanner);
    //    }
    //    public IActionResult ProductNew()
    //    { 
    ////         var latestProduct = _db.Products
    ////.OrderByDescending(item => item.CreatedDate) // Sắp xếp theo CreatedAt giảm dần
    ////.FirstOrDefault(); // Lấy bản ghi đầu tiên

    //        DateTime endDate = DateTime.Now; // Thời điểm hiện tại
    //        DateTime startDate = endDate.AddDays(-10); // Trừ 10 ngày từ thời điểm hiện tại

    //        var productsInTimeRange = _db.GetProducts
    //            .Where(p => p.CreatedDate >= startDate && p.CreatedDate <= endDate).Take(3)
    //            .ToList();
    //        return View("_ProductNew", productsInTimeRange);
    //    }
    //    public IActionResult ProductSale()
    //    {
           
    //        List<Product> saleProducts = _db.GetProducts.Where(item => item.Sale == true).Take(3).ToList();

           
    //        return View("_ProductSale", saleProducts);
    //    }
    //    public IActionResult TopRatedProducts()
    //    {
    //        List<Product> TopRatedProducts = _db.GetProducts.Where(item => item.Rating > 3).Take(3).ToList();

    //        return View("_TopRatedProducts", TopRatedProducts);
    //    }
    //    public IActionResult New()
    //    {
    //        var item = _db.GetNews.ToList();
    //        return View("_New", item);
    //    }
    }
}
