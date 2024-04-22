namespace OganiShopMVC.DataTransferObject
{
	public class ViewDTO<T> where T : class
	{
		public int TotalRows { get; set; } = 0;
		public List<T> DataRows { get; set; } = new List<T>();
		public string Message { get; set; } = "";
		public int StatusCode { get; set; } = 200;
	}
}
