using System.ComponentModel.DataAnnotations.Schema;

namespace OganiShopMVC.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get;set; } = new List<ShoppingCartItem>();

        public void AddItem (Product product , int quantity)
        {
            ShoppingCartItem? item = Items.Where(p=>p.id == product.id).FirstOrDefault();
            if (item == null)
            {
                Items.Add(new ShoppingCartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product) =>Items.RemoveAll(l=>l.Product.id == product.id);
        
       public decimal TotalPrice()=> (decimal)Items.Sum(e=>e.Product?.Price * e.Quantity);

        public void Clear() => Items.Clear();
        
    }

    public class ShoppingCartItem : Base
    {
       
        public Product? Product { get; set; } = new();
       
        public int? Quantity { get; set; }
    }
}
