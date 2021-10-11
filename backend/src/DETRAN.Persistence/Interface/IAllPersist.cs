using System.Threading.Tasks;
using DETRAN.Domain.Entities;

namespace DETRAN.Persistence.Interface
{
    public interface IAllPersist
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}