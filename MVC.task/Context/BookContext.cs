using Microsoft.EntityFrameworkCore;
using MVC.task.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.task.Context
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Trusted_Connection=true;Encrypt=false");
        }

    }

    
} 
