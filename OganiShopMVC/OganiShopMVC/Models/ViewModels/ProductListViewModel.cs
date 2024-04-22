namespace OganiShopMVC.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> products { get; set; } = Enumerable.Empty<Product>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();    
    }
}
