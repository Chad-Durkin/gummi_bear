using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gummi_Bear.Model
{
    public class GummiBearDbContext : DbContext
    {
        public GummiBearDbContext()
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GummiBearWithMigrations;integraded security=True");
        }
        public GummiBearDbContext(DbContextOptions<GummiBearDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
