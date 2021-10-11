using System.Linq;
using System.Threading.Tasks;
using DETRAN.Domain.Entities;
using DETRAN.Persistence.Data.Context;
using DETRAN.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace DETRAN.Persistence.Repository
{
    public class VeiculoPersist : IVeiculoPersist
    {
        private readonly DetranContext _context;
        public VeiculoPersist(DetranContext context)
        {
            _context = context;
        }
        public async Task<Veiculo[]> GetAllVeiculosAsync(bool includeCondutor)
        {
            IQueryable<Veiculo> query = _context.Veiculos;

            if(includeCondutor){
                query = query
                .Include(v => v.VeiculoCondures)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.OrderBy(v => v.VeiculoId);
            return await query.ToArrayAsync();
        }

        public async Task<Veiculo[]> GetAllVeiculosByCondutorAsync(string marca, bool includeCondutor = false)
        {
            IQueryable<Veiculo> query = _context.Veiculos;
            
            if(includeCondutor){
                query = query
                .Include(c => c.VeiculoCondures)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.OrderBy(e => e.CondutorId).Where(c => c.Marca.ToLower().Contains(marca.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int veiculoId, bool includeCondutor)
        {
            IQueryable<Veiculo> query = _context.Veiculos;

            if(includeCondutor){
                query = query
                .Include(c => c.VeiculoCondures)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.OrderBy(e => e.VeiculoId)
            .Where(e => e.VeiculoId == veiculoId);
            return await query.FirstOrDefaultAsync();
        }
    }
}