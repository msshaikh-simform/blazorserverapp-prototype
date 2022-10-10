using Microsoft.EntityFrameworkCore;
using QuotationMgmtSystem.Data;

namespace QuotationMgmtSystem.ApplicationDbContext
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// It's custom extension method used to pre-populate master data
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedMasterData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    UserName = "msshaikh",
                    Password = "msshaikh",
                    Role = "CSM",
                },
                new User()
                {
                    UserId = 2,
                    UserName = "vivekupla",
                    Password = "vivekupla",
                    Role = "QuoteStaff"
                },
                new User()
                {
                    UserId = 3,
                    UserName = "admin",
                    Password = "admin",
                    Role = "Administrator",
                }
            );
        }
    }
}