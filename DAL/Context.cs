using Microsoft.EntityFrameworkCore;
using RegistroCompras.Models;

namespace RegistroCompras.DAL
{
    //CONTEXTO LISTO.
    public class Context : DbContext
    {
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<ComprasId> Productos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public object Proyectos { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA/Compras.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>().HasData(
                 new Categorias()
                 {
                     CategoriaId = 1,
                     Descripcion = "Alimentos"
                 },
                 new Categorias()
                 {
                     CategoriaId = 2,
                     Descripcion = "Abarrotes"
                 }
            );

            modelBuilder.Entity<ComprasId>().HasData(
                new ComprasId
                {
                    ProductoId = 1,
                    Descripcion = "Huevos",
                    Costo = 5,
                    Precio = 7,
                    CategoriaId = 1,
                    Existencia = 0
                },
                new ComprasId
                {
                    ProductoId = 2,
                    Descripcion = "Cebolla",
                    Costo = 50,
                    Precio = 85,
                    CategoriaId = 1,
                    Existencia = 0
                }
            );
        }
    }
}