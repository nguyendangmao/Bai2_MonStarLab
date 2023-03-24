
using JobNetCore6.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobNetCore6.Entities
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<AppUser>? AppUsers{get; set;}
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Family" },
                    new Category { Id = 2, Name = "Shool" },
                    new Category { Id = 3, Name = "Play" },
                    new Category { Id = 4, Name = "Game" }
                );

            modelBuilder.Entity<Job>().HasData(

                new Job { Id = 1, Name = "Làm Toán", Content = "Làm 10 bài toán nanng cao", DateStart = Convert.ToDateTime("2010-10-19"), Status = false, CategoryId = 1 },
                new Job { Id = 2, Name = "Làm văn", Content = "Làm 20 bài văn nanng cao", DateStart = Convert.ToDateTime("2010-10-18"), Status = false, CategoryId = 2 },
                new Job { Id = 3, Name = "Làm lí ", Content = "Làm 30 bài lí nanng cao", DateStart = Convert.ToDateTime("2010-10-17"), Status = true, CategoryId = 3 },
                new Job { Id = 4, Name = "Làm Hóa", Content = "Làm 5 bài Hóa nanng cao", DateStart = Convert.ToDateTime("2010-10-16"), Status = false, CategoryId = 4 }

                );
        }
    }
}
