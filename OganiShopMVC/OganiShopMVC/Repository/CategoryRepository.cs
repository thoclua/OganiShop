using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
	public interface ICategory : IBaseRepository<Category>
	{
	}
	public class CategoryRepository : BaseRepository<Category>, ICategory
	{
		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
