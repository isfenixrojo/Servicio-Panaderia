using System.ComponentModel.DataAnnotations;

namespace API.Panaderia.Dominio.DTOs
{
    public class ViewPanDTO
    {
        
        public required string NombrePan { get; set; }        
        public required string Descripcion { get; set; }           
        public string? Color { get; set; }
    }
}
