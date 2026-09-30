using System.ComponentModel.DataAnnotations;

namespace API.Panaderia.Dominio.DTOs
{
    public class CreatePanDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(70, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos.")]
        public required string NombrePan { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos.")]
        public required string Descripcion { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos.")]
        public string? Color { get; set; }
    }
}
