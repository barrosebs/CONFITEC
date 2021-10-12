using System.Linq;
using System.Threading.Tasks;
using DETRAN.Domain.Entities;
using DETRAN.Persistence.Data.Context;
using DETRAN.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace DETRAN.Persistence.Repository
{
    public class CondutorPersist : ICondutorPersist
    {
        private readonly DetranContext _context;
        public CondutorPersist(DetranContext context)
        {
            _context = context;
        }
        public async Task<Condutor[]> GetAllCondutoresByVeiculoAsync(string condutor, bool includeVeiculo = false)
        {
            IQueryable<Condutor> query = _context.Condutores;
            
            if(includeVeiculo){
                query = query
                .Include(c => c.CondutorVeiculos)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.AsNoTracking().OrderBy(e => e.CondutorId).Where(c => c.Nome.ToLower().Contains(condutor.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Condutor[]> GetAllCondutoresAsync(bool includeVeiculo = false)
        {
            IQueryable<Condutor> query = _context.Condutores;

            if(includeVeiculo){
                query = query
                .Include(c => c.CondutorVeiculos)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.AsNoTracking().OrderBy(e => e.CondutorId);
            return await query.ToArrayAsync();
        }
        public async Task<Condutor> GetCondutorByIdAsync(int condutorId, bool includeVeiculo = false)
        {
            IQueryable<Condutor> query = _context.Condutores;

            if(includeVeiculo){
                query = query
                .Include(c => c.CondutorVeiculos)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.AsNoTracking().OrderBy(e => e.CondutorId)
            .Where(e => e.CondutorId == condutorId);
            return await query.FirstOrDefaultAsync();
        }
    }
}