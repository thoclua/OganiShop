using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;
using OganiShopMVC.Repository;

namespace OganiShopMVC.Controllers
{
    public class OrderController : Controller
    {
        private IBaseRepository<Order> _OrderRepository;
        private ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context, IBaseRepository<Order> OrderRepository)
        {
            _context = context;
            _OrderRepository = OrderRepository;
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
            var result = _OrderRepository.BuildResponseForDataTableLibrary(
                r => (string.IsNullOrEmpty(search)) || (
                    (!string.IsNullOrEmpty(search)) && (
                        r.Address.ToLower().Contains(search.ToLower())
                    )
                ),
                columName,
                columASC,
                start,
                postModel.draw,
                length
                //"CategoryOrder"

                );




            return View(result);
        }

        [HttpGet]
        public IActionResult CreateOrUpdate(int Id)
        {
            //ViewBag.CategoryId = new SelectList(_context.GetOrders.ToList(), "id", "Title");
            var model = new Order();
            if (Id > 0)
            {
                var data = _OrderRepository.GetById(Id);
                model = data.DataRows.FirstOrDefault();
            }

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Save(Order entity)
        {
            var result = _OrderRepository.Save(entity.id, entity);
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = _OrderRepository.Delete(Id);
            return View(result);
        }
    }
}
