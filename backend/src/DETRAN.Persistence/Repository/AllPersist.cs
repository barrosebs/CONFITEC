using System.Linq;
using System.Threading.Tasks;
using DETRAN.Domain.Entities;
using DETRAN.Persistence.Data.Context;
using DETRAN.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace DETRAN.Persistence.Repository
{
    public class AllPersist : IAllPersist
    {
        private readonly DetranContext _context;
        public AllPersist(DetranContext context)
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
    }
}