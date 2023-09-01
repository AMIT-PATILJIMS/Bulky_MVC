using Microsoft.EntityFrameworkCore;
using BulkyWeb_Temp.Models;

namespace BulkyWeb_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Displayorder = 1 },
                new Category { Id = 2, Name = "Laddu", Displayorder = 2 },
                new Category { Id = 3, Name = "Gopal", Displayorder = 3 }
                );
        }
    }
}
