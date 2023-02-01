using app.Features.Assignments;
namespace app.Database;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<AssignmentModel> Assignments { get; set; }
}