using Microsoft.AspNetCore.Identity;

namespace OganiShopMVC.Data
{
    public  class DbSeedRole 
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbSeedRole(RoleManager<IdentityRole> roleManager )
        {
            _roleManager = roleManager;
        }
        public  async Task RoleData()
        {
            var roleContext = await _roleManager.CreateAsync(new IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "KETOAN", NormalizedName = "KETOAN" });
            
        }                   
    }
}

//nhận đối tg RoleManager<IdentityRole>
//1 phg thức  rDT