using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OganiShopMVC.Data;
using OganiShopMVC.Models;
using System.Diagnostics;
//using X.PagedList;

namespace OganiShopMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;
        public HomeController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userName, RoleManager<IdentityRole> roleManager) : base(contextAccessor, userName, roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> SeedingRole()
        {
            var dbSeedRole = new DbSeedRole(_roleManager);
            await dbSeedRole.RoleData();
            return Ok("Seed Role Thành Công");
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser != null)
            {
                ViewBag.HT = currentUser.UserName;
            }

            //int pageSize = 8;
            //int pageNumber = page == null || page < 0 ? 1 : page.Value;
            //var lstsanpham = _context.Products.AsNoTracking().OrderBy(x => x.Name);
            //PagedList<Product> ls = new PagedList<Product>(lstsanpham,pageNumber,pageSize);

           

            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}