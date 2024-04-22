using System.ComponentModel.DataAnnotations;

namespace OganiShopMVC.Models
{
	public class Base
	{
		[Key]
		public int id { get; set; }

		public DateTime? CreatedDate { get; set; } = DateTime.Now;

		public string? CreatedBy { get; set; }

		public DateTime? Modifiedrdate { get; set; } = DateTime.Now;

		public string? Modifiedby { get; set; }

		public bool? isDeleted { get; set; }

    }
}
