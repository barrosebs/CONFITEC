using System.Linq;
using System.Threading.Tasks;
using DETRAN.Domain.Entities;
using DETRAN.Persistence.Data.Context;
using DETRAN.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace DETRAN.Persistence.Repository
{
    public class DetranPersistence : IDetranPersistence
    {
        private readonly DetranContext _context;
        public DetranPersistence(DetranContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        public async Task<Condutor[]> GetAllCondutoresByAsync(string condutor, bool includeVeiculo = false)
        {
            IQueryable<Condutor> query = _context.Condutores;
            
            if(includeVeiculo){
                query = query
                .Include(c => c.CondutorVeiculos)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.OrderBy(e => e.CondutorId).Where(c => c.Nome.ToLower().Contains(condutor.ToLower()));
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
            query = query.OrderBy(e => e.CondutorId);
            return await query.ToArrayAsync();
        }

        public Task<Veiculo[]> GetAllVeiculoesCondutorAsync(bool includeCondutor)
        {
            throw new System.NotImplementedException();
        }

        public Task<Veiculo[]> GetAllVeiculosByCondutorAsync(string Veiculo, bool includeCondutor = false)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Condutor> GetCondutorByIdAsync(int CondutorId, bool includeVeiculo = false)
        {
            IQueryable<Condutor> query = _context.Condutores;

            if(includeVeiculo){
                query = query
                .Include(c => c.CondutorVeiculos)
                .ThenInclude(p => p.Veiculo);
            }
            query = query.OrderBy(e => e.CondutorId)
            .Where(e => e.CondutorId == CondutorId);
            return await query.FirstOrDefaultAsync();
        }

        public Task<Veiculo> GetVeiculoByIdAsync(int VeiculoId, bool includeCondutor)
        {
            throw new System.NotImplementedException();
        }

    }
}