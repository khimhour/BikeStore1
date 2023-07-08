using BikeStores1.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStores1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
