namespace OganiShopMVC.Models
{
	public class OrderDetail : Base
	{
		public string UserName { get; set; } 
		public int ProductId { get; set; } = 0;

		public decimal? Price { get; set; } = 0;

		public int Quantity { get; set; } = 0;

	}
}
