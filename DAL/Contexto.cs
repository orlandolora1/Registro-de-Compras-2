using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

public class Contexto : DbContext
{


    //QUE CLASE VAS A CREAR?


    //public DbSet<Categorias> Categorias { get; set; }
    //public DbSet<Productos> Productos { get; set; }
    //public DbSet<Compras> Compras { get; set; }

    //override 

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Categorias>().HasData(
    //      new Categorias() {CategoriaId=1, Descripcion = "Alimentos" },
    //      new Categorias() {CategoriaId=2 ,Descripcion = "Abarrotes" }
    //    );

    //    modelBuilder.Entity<Productos>().HasData(
    //        new Productos
    //        {
    //            ProductoId=1,
    //            Descripcion = "Huevos",
    //            Costo = 5,
    //            Precio = 7,
    //            CategoriaId = 1,
    //            Existencia = 0
    //        },
    //        new Productos
    //        {
    //            ProductoId=2,
    //            Descripcion = "Cebolla",
    //            Costo = 50,
    //            Precio = 85,
    //            CategoriaId = 1,
    //            Existencia = 0
    //        }
    //        );
    //}
}


//MOVER CLASE CATEGORIAS A MODELS
//public class Categorias
//{
//    [Key]
//    public int CategoriaId { get; set; }
//    public String? Descripcion { get; set; }
//}

////MOVER CLASE PRODUCTOS A MODELS
//public class Productos
//{
//    [Key]
//    public int ProductoId { get; set; }
//    public String? Descripcion { get; set; }
//    public double Costo { get; set; }
//    public double Precio { get; set; }
//    public int CategoriaId { get; set; }
//    public double Existencia { get; set; }
//}
////MOVER CLASE COMPRAS A MODELS
//public class Compras
//{
//    [Key]
//    public int CompraId { get; set; }
//    public DateTime Fecha { get; set; }

//    [ForeignKey("CompraId")]
//    public List<ComprasDetalle> Detalle { get; set; } = new List<ComprasDetalle>();

//    public double Total { get; set; }

//    public override string? ToString()
//    {
//        return $"Compra: Id={CompraId}, Fecha={Fecha}, Total={Total}";
//    }
//}
////MOVER CLASE COMPRASDETALLES A MODELS
//public class ComprasDetalle
//{
//    [Key]
//    public int CompraDetalleId { get; set; }

//    public int CompraId { get; set; }
//    public int ProductoId { get; set; }
//    public double Cantidad { get; set; }
//    public double Costo { get; set; }

//    public override string? ToString()
//    {
//        return $"Detalle # {CompraDetalleId}, ProductoId= {ProductoId} , cantidad={Cantidad} ";
//    }
//}

