using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCompras.Models
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("CompraId")]
        public List<ComprasDetalle> Detalle { get; set; } = new List<ComprasDetalle>();

        public double Total { get; set; }
        public int ProductoId { get; internal set; }

        public override string? ToString()
        {
            return $"Compra: Id={CompraId}, Fecha={Fecha}, Total={Total}";
        }
    }
}
