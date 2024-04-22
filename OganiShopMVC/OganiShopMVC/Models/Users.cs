using System.ComponentModel.DataAnnotations.Schema;

namespace OganiShopMVC.Models
{
	public class Users : Base
	{
		public string Name { get; set; } = "";
        public string Email { get; set; }
        public int? Age { get; set; } = 0;	
        public string Password { get; set; }
        public string Phone { get; set; } = "";
        public string Address { get; set; } = ""; 
        
      

        
	}
}
