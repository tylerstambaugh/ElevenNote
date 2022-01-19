using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ElevenNote.Data
{

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

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    //public class UserConfiguration : IdentityDbContext<ApplicationUser>
    //{
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder
    //            .Conventions
    //            .Remove<PluralizingTableNameConvention>();

    //        modelBuilder
    //            .Configurations
    //            .Add(new IdentityUserLoginConfiguration())
    //            .Add(new IdentityUserRoleConfiguration());
    //    }
    //    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    //    {
    //        public IdentityUserLoginConfiguration()
    //        {
    //            //Think of a lambda expression as saying, "given something, return something".
    //            HasKey(iul => iul.UserId);
    //        }
    //    }

    //    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    //    {
    //        public IdentityUserRoleConfiguration()
    //        {
    //            HasKey(iur => iur.UserId);
    //        }
    //    }
    // }
}