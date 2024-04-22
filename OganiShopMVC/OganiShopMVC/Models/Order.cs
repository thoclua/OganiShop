using System.ComponentModel.DataAnnotations.Schema;
using Umbraco.Core.Models.Membership;

namespace OganiShopMVC.Models
{
	public class Order : Base
	{
		public string UserName { get; set; } = "";
		public string code { get; set; } = "";
		public string Phone { get; set; } = "";
		public string Address { get; set; } = "";
		public decimal? Totalmoney { get; set; } = 0;

		public string status { get; set; }  

	}
}
