using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.Models;
using OganiShopMVC.Models.ViewModels;
using System.Linq;


namespace OganiShopMVC.Controllers
{
    public class HienThiProductController : Controller
    {
        private ApplicationDbContext _db;
        public int PageSize = 9;
        public HienThiProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int productPage = 1)
        {
            //var items = _db.Products.ToList();
            //if (Id > 0)
            //{
            //    items = items.Where(p => p.CategoryId == Id).ToList();
            //}
         

            return View(new ProductListViewModel
            {
                products = _db.Products.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrenPage = productPage,
                    TotalItems = _db.Products.Count()
                }
            } )
                
                ;
        }
        [HttpPost]
        public IActionResult Search(string key , int productPage = 1)
        {
            


            return View("Index",new ProductListViewModel
            {
                products = _db.Products.Where(p=>p.Name.Contains(key)).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrenPage = productPage,
                    TotalItems = _db.Products.Count()
                }
            })

                ;
        }



        public ActionResult _Category(int Id)
        {
            var items = _db.Products.ToList();
            if (Id > 0)
            {
                items = items.Where(p => p.CategoryId == Id).ToList();
            }

            return View("_category",items);
        }
        public IActionResult Detail(int id)
        {
            var item = _db.Products.Find(id);


            return View(item);
        }


    }
}
