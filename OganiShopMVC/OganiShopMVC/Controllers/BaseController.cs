using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Models;

namespace OganiShopMVC.Controllers
{
    public class BaseController : Controller
    {

        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly UserManager<CustomUser> _userName;
        protected readonly RoleManager<IdentityRole> _roleManager;
        // private IHttpContextAccessor contextAccessor;
        
        public BaseController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userName, RoleManager<IdentityRole> roleManager)
        {
            _contextAccessor = contextAccessor;
            _userName = userName;
            _roleManager = roleManager;
        }

        //public BaseeeController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userName)
        //{
        //    this.contextAccessor = contextAccessor;
        //    this.userName = userName;
        //}

       

        protected async Task<CustomUser> GetCurrentUserAsync()
        {
            var currentUser = _contextAccessor.HttpContext.User;    //ng dung ht
            var ht = "";
            var userId = "";
            if (currentUser.Identity.IsAuthenticated)       //xac thuc ng dung
            {
                ht = currentUser.Identity.Name;
                var Usertimthay = await _userName.FindByNameAsync(currentUser.Identity.Name); //tim tt user dua tren tt user
                return Usertimthay;

            }
            else
            {
                ht = "Chua Dang Nhap";

            }
            ViewBag.HT = ht;
            return null;

        }

    }
}
