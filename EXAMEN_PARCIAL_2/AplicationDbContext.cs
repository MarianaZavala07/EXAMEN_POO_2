using EXAMEN_PARCIAL_2.Entities;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN_PARCIAL_2
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Juguete> juguetes{ get; set; }
        public DbSet<Marca> marca { get; set; }

    }
}