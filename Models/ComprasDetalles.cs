using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCompras.Models
{
    public class ComprasDetalle
    {
        [Key]
        public int CompraDetalleId { get; set; }

        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }

        [ForeignKey("ProductoId")]
        public ComprasId producto { get; set; }

        public override string? ToString()
        {
            return $"Detalle # {CompraDetalleId}, ProductoId= {ProductoId} , cantidad={Cantidad} ";
        }
    }
}
