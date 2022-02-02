using Microsoft.EntityFrameworkCore;
using Models;
using TodoPersistence.Util;

namespace TodoPersistence;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfidentialStuff.ConnectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasKey(user =>new
        {
            user.Username
        });
         

    }
}