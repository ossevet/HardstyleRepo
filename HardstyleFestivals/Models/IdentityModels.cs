using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HardstyleFestivals.Models
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
        

        //voeg hier dbSets toe van je classes in je Models directory. Dan worden er Tabellen van gemaakt in de DB
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }


      
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Festival>().Property(x => x.PrijsEarly).HasPrecision(18, 2);
           //modelBuilder.Entity<Festival>().Property(object => object.PrijsLate).HasPrecision(18, 2);
           //modelBuilder.Entity<Festival>().Property(object => object.KostService).HasPrecision(18, 2);
           //modelBuilder.Entity<Festival>().Property(object => object.KostBetaling).HasPrecision(18, 2);

           base.OnModelCreating(modelBuilder);
        }



        public ApplicationDbContext()  //geef hier de naam op van je connectiestring die je in je webconfig hebt staan (om connectie te maken met je externe DB)
            : base("SQLServerConnectionToHardstyleDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}