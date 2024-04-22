using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;
using OganiShopMVC.Repository;

namespace OganiShopMVC.Controllers
{
	[Authorize]
	public class ConfigController : Controller
	{
		private IBaseRepository<config> _ConfigRepository;
		private ApplicationDbContext _context;
		public ConfigController(ApplicationDbContext context, IBaseRepository<config> ConfigRepository)
		{
			_context = context;
			_ConfigRepository = ConfigRepository;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult DataTableAjaxRespone(DataTableAjaxPostModel postModel)
		{
			//Kiem tra search
			var search = "";
			if (postModel.search != null)
			{
				search = postModel.search.value;
			}

			//Kiem tra sap xep
			var columName = "id";
			var columASC = false;

			if (postModel.order != null)
			{
				columName = postModel.columns[postModel.order[0].column].name;
				if (postModel.order[0].dir.Equals("asc"))
				{
					columASC = true;
				}
				if (postModel.order[0].dir.Equals("desc"))
				{
					columASC = false;
				}
			}
			//Kiem tra phan trang
			var start = postModel.start;
			var length = postModel.length;

			//Goi vao Repository va dien cac tham so phu hop
			var result = _ConfigRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
					(!string.IsNullOrEmpty(search)) && (
						r.Config_Code.ToLower().Contains(search.ToLower())
					)
				),
				columName,
				columASC,
				start,
				postModel.draw,
			length


				);
			return Ok(result);
		}

		[HttpGet]
		public IActionResult CreateOrUpdateConfig(int Id)
		{

			var model = new config();
			if (Id > 0)
			{
				var data = _ConfigRepository.GetById(Id);
				model = data.DataRows.FirstOrDefault();
			}

			return PartialView(model);
		}

		[HttpPost]
		public IActionResult Save(config entity)
		{
			var result = _ConfigRepository.Save(entity.id, entity);
			return Ok(result);
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var result = _ConfigRepository.Delete(Id);
			return Ok(result);
		}
	}
}
