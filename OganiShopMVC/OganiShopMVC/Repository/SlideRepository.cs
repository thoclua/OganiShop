using OganiShopMVC.Data;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
	public interface Islide : IBaseRepository<Slide>
	{

	}
	public class SlideRepository : BaseRepository<Slide>, Islide
	{
		public SlideRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
