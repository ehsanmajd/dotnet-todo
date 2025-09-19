using Microsoft.EntityFrameworkCore;
using TodoList.Models;


namespace TodoList.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<TodoTask>().pri
        // Optional: Seed initial data
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Title = "Buy groceries" },
            new Category { Id = 2, Title = "Do laundry" }
        );
    }
}