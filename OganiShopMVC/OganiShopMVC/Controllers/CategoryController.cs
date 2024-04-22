using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;
using OganiShopMVC.Repository;

namespace OganiShopMVC.OganiShopMVC
{
    [Authorize]
	public class CategoryController : Controller
	{
        private IBaseRepository<Category> _CategoryRepository;
        private ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context, IBaseRepository<Category> CategoryRepository)
        {
            _context = context;
            _CategoryRepository = CategoryRepository;
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
            var result = _CategoryRepository.BuildResponseForDataTableLibrary(
                r => (string.IsNullOrEmpty(search)) || (
                    (!string.IsNullOrEmpty(search)) && (
                        r.CategoryName.ToLower().Contains(search.ToLower())
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
        public IActionResult CreateOrUpdateCategory(int Id)
        {

            var model = new Category();
            if (Id > 0)
            {
                var data = _CategoryRepository.GetById(Id);
                model = data.DataRows.FirstOrDefault();
            }

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Save(Category entity)
        {
            var result = _CategoryRepository.Save(entity.id, entity);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = _CategoryRepository.Delete(Id);
            return Ok(result);
        }
    }
}
