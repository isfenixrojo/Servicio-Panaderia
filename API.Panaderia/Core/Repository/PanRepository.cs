using API.Panaderia.Core.Interfaces;
using API.Panaderia.Datos;
using API.Panaderia.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API.Panaderia.Core.Repository
{
    public class PanRepository : IPanRepository
    {
        private readonly ApplicationDbContext _context;

        #region Contructor
        public PanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion Contructor

        public async Task<Pan?> PostPanAsync(Pan pan)
        {
            pan.Disponible = true;
            pan.FechaCreacion = DateTime.UtcNow;
            await _context.Panes.AddAsync(pan);
            await _context.SaveChangesAsync();
            return pan;
        }

        public async Task<List<Pan>> GetPanAsync()
        {
            var listaPanes = await _context.Panes.ToListAsync();
            return listaPanes;
        }

        public async Task<Pan> GetPanByIdAsync(int idPan)
        {
            var pan = await _context.Panes.FindAsync(idPan);
            return pan;
        }

        public async Task<Pan?> UpdatePanAsync(int idPan, Pan pan)
        {
            var existePan = _context.Panes.FirstOrDefaultAsync(x => x.IdPan == idPan);
            if (existePan == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return pan;
        }
        public async Task<bool> DeletePanAsync(int idPan)
        {
            bool mensaje = false;
            var pan = await _context.Panes.FirstOrDefaultAsync(x => x.IdPan == idPan);
            if (pan == null)
            {
                return false;
            }

            _context.Panes.Remove(pan);
            await _context.SaveChangesAsync();
            return mensaje = true;
        }
    }
}
