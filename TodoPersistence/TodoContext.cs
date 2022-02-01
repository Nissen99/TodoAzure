using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoPersistence;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=tcp:tododatabase.database.windows.net,1433;Initial Catalog=TodoSQLDatabase;Persist Security Info=False;User ID=tododatabase;Password=Cpd85khv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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