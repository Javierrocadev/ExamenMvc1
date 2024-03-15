using ExamenMvc1.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenMvc1.Data
{
    public class ZapatillaContext : DbContext
    {
        public ZapatillaContext(DbContextOptions<ZapatillaContext> options) : base(options)
        {
        }

        public DbSet<Zapatilla> Zapatillas { get; set; }

        public DbSet<Imagen> Imagenes { get; set; }
    }
}
