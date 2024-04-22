using System.ComponentModel.DataAnnotations.Schema;

namespace OganiShopMVC.Models
{
	public class New : Base
	{	
		public string Title { get; set; } = "";


		public string Description { get; set; } = "";

		public string Image { get; set; } = "";

        public int? CategoryNewId { get; set; }

        [ForeignKey("CategoryNewId")]
        public CategoryNew? CategoryNew { get; set; }

    }
}
