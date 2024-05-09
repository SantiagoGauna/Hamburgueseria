using Microsoft.EntityFrameworkCore;
using Clases;

namespace DAO
{
    public class Hamburgueseria : DbContext
    {
        public Hamburgueseria(DbContextOptions<Hamburgueseria> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Hamburguesa> Hamburguesa { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Ingrediente> Ingrediente {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las claves primarias
            modelBuilder.Entity<Cliente>().HasKey(c => c.idCliente);
            modelBuilder.Entity<Hamburguesa>().HasKey(h => h.idHamburguesa);
            modelBuilder.Entity<Pedido>().HasKey(p => p.idPedido);
            modelBuilder.Entity<Ingrediente>().HasKey(i => i.idIngrediente);

            // Configuración de las relaciones
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.idCliente);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Hamburguesa)
                .WithMany()
                .HasForeignKey(p => p.idHamburguesa);
        }


    }
}
