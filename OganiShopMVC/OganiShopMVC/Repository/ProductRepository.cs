using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
	public interface IProduct : IBaseRepository<Product>
	{
	}
	public class ProductRepository : BaseRepository<Product>, IProduct
	{
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
