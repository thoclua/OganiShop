using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;
using OganiShopMVC.Repository;

namespace OganiShopMVC.Controllers
{
	[Authorize]
	public class ProductController : Controller
	{
		
		private IBaseRepository<Product> _ProductRepository;
		private ApplicationDbContext _context;
		public ProductController(ApplicationDbContext context, IBaseRepository<Product> ProductRepository)
		{
			_context = context;
			_ProductRepository = ProductRepository;
		}
		public IActionResult Index()
		{
			return View();
		}
        //[HttpPost]
        //[Route("Sort/page/search")]
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

			var result = _ProductRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
			//Goi vao Repository va dien cac tham so phu hop
					(!string.IsNullOrEmpty(search)) && (
						r.Name.ToLower().Contains(search.ToLower())
					)
				),
				columName,
				columASC,
				start,
				postModel.draw,
				length,
				"Category"

				);



            return Ok(result);

        }

		[HttpGet]
      //  [Route("CreateOrUpdate")]
        public IActionResult CreateOrUpdate(int Id)
		{
			ViewBag.CategoryId = new SelectList(_context.Categorys.ToList(), "id", "CategoryName");
			var model = new Product();
			if (Id > 0)
			{
				var data = _ProductRepository.GetById(Id);
                model = data.DataRows.FirstOrDefault();
			}

			return PartialView(model);
		}

		[HttpPost]
		public IActionResult Save(Product entity)
		{
			var result = _ProductRepository.Save(entity.id, entity);
			return Ok(result);
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var result = _ProductRepository.Delete(Id);
			return Ok(result);
		}
	}
}
