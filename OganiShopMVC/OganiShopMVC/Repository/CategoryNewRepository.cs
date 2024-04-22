using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
    public interface ICategoryNew : IBaseRepository<CategoryNew>
    {
    }
    public class CategoryNewRepository : BaseRepository<CategoryNew>, ICategoryNew
    {
        public CategoryNewRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
