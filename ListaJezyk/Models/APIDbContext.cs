using Microsoft.EntityFrameworkCore;

namespace ListaJezyk.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
            
        }

        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Jezyk> Jezyki { get; set;}
    }
}
