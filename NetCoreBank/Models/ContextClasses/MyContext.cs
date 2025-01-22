using Microsoft.EntityFrameworkCore;
using NetCoreBank.Models.Entities;
using NetCoreBank.Models.SeedHandling;

namespace NetCoreBank.Models.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt):base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserCardInfoSeed.SeedUserCard(modelBuilder);
        }

        public DbSet<UserCardInfo> CardInfoes { get; set; }
    }
}
