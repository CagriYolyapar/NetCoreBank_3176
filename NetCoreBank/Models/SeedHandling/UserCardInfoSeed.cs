using Microsoft.EntityFrameworkCore;
using NetCoreBank.Models.Entities;

namespace NetCoreBank.Models.SeedHandling
{
    public static class UserCardInfoSeed
    {
        public static void SeedUserCard(ModelBuilder modelBuilder)
        {
            UserCardInfo uInfo = new()
            {
                Id = 1,
                Balance = 100000,
                CardLimit = 100000,
                CardNumber = "1111 1111 1111 1111",
                CardUserName = "Test verisidir",
                CVV = "222",
                ExpiryMonth = 12,
                ExpiryYear = 2025
            };
            modelBuilder.Entity<UserCardInfo>().HasData(uInfo);
        }
    }
}
