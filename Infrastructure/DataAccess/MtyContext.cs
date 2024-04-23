using Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace Mty.Infrastructure.DataAccess;

public class MtyContext : DbContext
{
    public MtyContext(DbContextOptions options): base(options)
    {
        
    }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Parent>? Parents { get; set; }
}
