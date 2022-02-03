using Microsoft.EntityFrameworkCore;
using Models;
using TodoPersistence.Util;

namespace TodoPersistence;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todo { get; set; }
    public DbSet<User> User { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfidentialStuff.ConnectionString);

    }
    
}