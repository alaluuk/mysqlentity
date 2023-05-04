using Entitytest.Models.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace Entitytest.Data;
 
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
 
    }
    public DbSet<User> User { get; set; }
    public DbSet<Book> Book { get; set; }
}