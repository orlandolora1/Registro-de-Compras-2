using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCompras.Models
{
    public class ComprasId
    {
        internal IEnumerable<object> Detalle;

        [Key]
        public int ProductoId { get; set; }
        public String? Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public double Existencia { get; set; }
        [ForeignKey("CategoriaId")]
        public Categorias categoria { get; set; }
    }
}
