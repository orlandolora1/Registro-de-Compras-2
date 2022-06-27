using System.ComponentModel.DataAnnotations;

namespace RegistroCompras.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public String? Descripcion { get; set; }
    }
}
