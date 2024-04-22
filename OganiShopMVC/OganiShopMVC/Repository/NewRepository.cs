using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
	public interface INew : IBaseRepository<New>
	{

	}
	public class NewRepository : BaseRepository<New>, INew
	{
		public NewRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
