namespace OganiShopMVC.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } // có bao nhiêu thông tin

        public int ItemsPerPage { get; set; } // bao nhiêu sp trên 1 trang

        public int CurrenPage { get; set; }  // trang hiện tại
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); // tổng số trang
    }
}
