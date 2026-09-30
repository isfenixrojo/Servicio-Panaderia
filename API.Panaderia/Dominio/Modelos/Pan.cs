using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Panaderia.Dominio.Modelos
{
    public class Pan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPan { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(70, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos.")]
        public required string NombrePan { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos.")]
        public required string Descripcion { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos.")]
        public string? Color { get; set; }

        public bool Disponible { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
