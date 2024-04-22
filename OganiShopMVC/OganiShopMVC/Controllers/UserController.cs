using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OganiShopMVC.Models;

namespace OganiShopMVC.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userName, RoleManager<IdentityRole> roleManager) : base(contextAccessor, userName, roleManager)
        {
        }

        public IActionResult Index()
        {
            var dsusser = _userName.Users.ToList();
            return View(dsusser);
        }
        public async Task<IActionResult> ViewUpdate(string id)
        {
            var userCanTim = await _userName.FindByIdAsync(id);
            return PartialView(userCanTim);
        }

        [HttpPost]
        public async Task<IActionResult> doUpdate([Bind("Id,PhoneNumber,FullName,Email")] CustomUser user)
        {
            if (user != null)
            {
                var usercantim = await _userName.FindByIdAsync(user.Id);
                if (usercantim != null)
                {
                    usercantim.PhoneNumber = user.PhoneNumber;
                    usercantim.FullName = user.FullName;
                    //  usercantim.PhoneNumber = user.PhoneNumber;
                    usercantim.Email = user.Email;

                    await _userName.UpdateAsync(usercantim);
                    TempData["ThanhCong"] = "Cap Nhat Thanh Cong!";
                    return Redirect("/User");

                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> ViewSetRole(string id)
        {
            var userdcchon = await _userName.FindByIdAsync(id);
            var dsALLquyen = await _roleManager.Roles.ToListAsync();
            if (userdcchon != null)
            {
                var userRole = await _userName.GetRolesAsync(userdcchon);
                ViewBag.userRole = userRole.ToList();
                ViewBag.userId = id;
            }
            return PartialView(dsALLquyen);
        }

        [HttpPost]
        public async Task<IActionResult> doSetRole(string userid, List<string> arrRole)
        {
            var userduocchon = await _userName.FindByIdAsync(userid);
            var dsAllQuyen = await _roleManager.Roles.ToListAsync();
            var arrstingQuyen = dsAllQuyen.Select(x => x.Name);
            if (userduocchon != null)
            {
                await _userName.RemoveFromRolesAsync(userduocchon, arrstingQuyen);
                await _userName.AddToRolesAsync(userduocchon, arrRole);

                TempData["ThanhCong"] = "Cap Nhat quyen Thanh Cong!";
                return Redirect("/User");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string userid)
        {
            var userduocchon = await _userName.FindByIdAsync(userid);
            if (userduocchon != null)
            {
                await _userName.DeleteAsync(userduocchon);
                return Ok("bạn đã xoá thành công");
            }
            return BadRequest();

        }
    }
}
