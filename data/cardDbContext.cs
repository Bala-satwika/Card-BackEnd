using apiAndAsp.models;
using Microsoft.EntityFrameworkCore;
namespace apiAndAsp.data
{
    public class cardDbContext : DbContext
    {
        public cardDbContext(DbContextOptions options) : base(options)
        {
        }
        //dbset acts as table in sql server
public DbSet<card> cards { get; set; }
    }
}
