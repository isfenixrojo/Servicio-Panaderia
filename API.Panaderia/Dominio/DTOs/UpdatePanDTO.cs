namespace API.Panaderia.Dominio.DTOs
{
    public class UpdatePanDTO : CreatePanDTO
    {
        public bool Disponible { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
