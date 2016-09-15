using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Agency.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Agency.Models.OBJECT_KIND> OBJECT_KIND { get; set; }

        public System.Data.Entity.DbSet<Agency.Models.OBJECT_TYPE> OBJECT_TYPE { get; set; }

        public System.Data.Entity.DbSet<Agency.Models.AD_TYPE> AD_TYPE { get; set; }


        public System.Data.Entity.DbSet<Agency.Models.Ad> Ads { get; set; }

        public System.Data.Entity.DbSet<Agency.Models.OBJ> OBJs { get; set; }

        public System.Data.Entity.DbSet<Agency.Models.DISCOUNT> DISCOUNTs { get; set; }
    }
}