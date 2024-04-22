namespace OganiShopMVC.DataTransferObject
{
	public class DataTableAjaxPostModel
	{
			public int draw { get; set; } // Số nguyên duy nhất được gửi lại bởi DataTables để xác định các yêu cầu bất biến.
			public int start { get; set; } // Chỉ mục bắt đầu của bản ghi trong danh sách hiển thị hiện tại.
			public int length { get; set; } // Số lượng bản ghi được yêu cầu để hiển thị trên mỗi trang.
			public List<Column> columns { get; set; } // Danh sách các cột trong bảng.
			public Search search { get; set; } // Thông tin về tìm kiếm.
			public List<Order> order { get; set; } // Thông tin về sắp xếp.
		
		public class Column
		{
			public string data { get; set; }  // Tên của cột dữ liệu.
			public string name { get; set; } // Tên của cột.
			public bool searchable { get; set; }   // Có cho phép tìm kiếm trong cột hay không
			public bool orderable { get; set; } // Có cho phép sắp xếp theo cột hay không
			public Search search { get; set; } // Thông tin tìm kiếm cho cột.
		}

		public class Search
		{
			public string value { get; set; }  // Giá trị tìm kiếm.
			public string regex { get; set; }  // Có sử dụng biểu thức chính quy cho tìm kiếm hay không.
		}

		public class Order
		{
			public int column { get; set; }  // Chỉ mục cột dùng để sắp xếp.
			public string dir { get; set; }  // Hướng sắp xếp (asc hoặc desc)
		}
	}
}
