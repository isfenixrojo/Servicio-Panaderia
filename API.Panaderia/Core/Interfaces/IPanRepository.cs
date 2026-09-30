using API.Panaderia.Dominio.Modelos;

namespace API.Panaderia.Core.Interfaces
{
    public interface IPanRepository
    {
        Task<Pan?> PostPanAsync(Pan pan);
        Task<List<Pan>> GetPanAsync();
        Task<Pan> GetPanByIdAsync(int idPan);
        Task<Pan?> UpdatePanAsync(int idPan, Pan pan);
        Task<bool> DeletePanAsync(int idPan);
    }
}
