using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
	public interface IConfig : IBaseRepository<config>
	{

	}
	public class ConfigRepository : BaseRepository<config>, IConfig
	{
		public ConfigRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
