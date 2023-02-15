using Microsoft.EntityFrameworkCore;
using trackingapi.Model;

namespace trackingapi.Data;
public class issueDbContext : DbContext
{
	public issueDbContext(DbContextOptions<issueDbContext> options):base(options)
	{
	}
	//DbSet is representation of Table in DB
    public DbSet<issue> Issues { get; set; }
}
