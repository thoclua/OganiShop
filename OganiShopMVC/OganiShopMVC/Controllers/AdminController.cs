using Microsoft.AspNetCore.Mvc;

namespace OganiShopMVC.Controllers
{
	public class AdminController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
