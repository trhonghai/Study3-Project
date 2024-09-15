using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NET.Data.Providers;

namespace NET.Data
{
    public class Study3DbContext : IdentityDbContext<ApplicationUser>
    {
        public Study3DbContext(DbContextOptions<Study3DbContext> options) : base(options)
        {
        }
        #region 
        public DbSet<ApplicationUser>? Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
    }
}