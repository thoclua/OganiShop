using Microsoft.AspNetCore.Identity;

namespace OganiShopMVC.Models
{
    public class CustomUser : IdentityUser
    {
        public string FullName { get; set; } = "";
    }
}
