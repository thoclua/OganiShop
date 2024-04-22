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
    public class NewController : Controller
    {
        private IBaseRepository<New> _NewRepository;
        private ApplicationDbContext _context;
        public NewController(ApplicationDbContext context, IBaseRepository<New> NewRepository)
        {
            _context = context;
            _NewRepository = NewRepository;
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

            //Goi vao Repository va dien cac tham so phu hop
            var result = _NewRepository.BuildResponseForDataTableLibrary(
                r => (string.IsNullOrEmpty(search)) || (
                    (!string.IsNullOrEmpty(search)) && (
                        r.Title.ToLower().Contains(search.ToLower())
                    )
                ),
                columName,
                columASC,
                start,
                postModel.draw,
                length,
                "CategoryNew"

                );



            return Ok(result);

        }

        [HttpGet]
        //  [Route("CreateOrUpdate")]
        public IActionResult CreateOrUpdate(int Id)
        {
            ViewBag.CategoryNewId = new SelectList(_context.CategoryNews.ToList(), "id", "CategoryName");
            var model = new New();
            if (Id > 0)
            {
                var data = _NewRepository.GetById(Id);
                model = data.DataRows.FirstOrDefault();
            }

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Save(New entity)
        {
            var result = _NewRepository.Save(entity.id, entity);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = _NewRepository.Delete(Id);
            return Ok(result);
        }
    }
}
