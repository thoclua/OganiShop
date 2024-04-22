using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;

namespace OganiShopMVC.Repository
{
    public interface IShopingCart : IBaseRepository<ShoppingCartItem>
    {
     //  List<Cartmini> GetCartMini(int Id);
    }
    public class ShopingCartRepository : BaseRepository<ShoppingCartItem>, IShopingCart
    {
        public ShopingCartRepository(ApplicationDbContext context) : base(context)
        {

        }
        //public List<Cartmini> GetCartMini(int Id)
        //{
        //    var query = _db.ShopingCartItems.Where(r => r.isDeleted != true);
        //    var result = from q in _db.ShopingCartItems.Where(r => r.isDeleted != true)
        //                 join p in _db.Products.AsQueryable() on q.ProductId equals p.id
        //                 where q.id.Equals(Id)
        //                 select new Cartmini
        //                 {
        //                     Id = q.id,
        //                     name = p.Name,
        //                     price = p.Price,
        //                     quantity = p.Quantity,
        //                     totalprice = p.Price * p.Quantity,
        //                     image = p.Image,

        //                 };
        //    var returnValue = result.ToList();

        //    return returnValue;
        //}
    }
}
