using Microsoft.EntityFrameworkCore;
using WebDomain.Entities;

namespace WebHost.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<ProductEntity> ProductEntity { get; set; }
    }
}
