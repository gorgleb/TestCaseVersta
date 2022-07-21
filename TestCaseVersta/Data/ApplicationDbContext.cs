using Microsoft.EntityFrameworkCore;
using TestCaseVersta.Models;

namespace TestCaseVersta.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Order> Orders { get; set; }

}
