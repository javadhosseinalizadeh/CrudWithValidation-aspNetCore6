using Microsoft.EntityFrameworkCore;
using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Data
{
    public static class SeedFirstData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    PersonnelCode = "E6425741",
                    IsActive = true,
                });
        }
    }
}
