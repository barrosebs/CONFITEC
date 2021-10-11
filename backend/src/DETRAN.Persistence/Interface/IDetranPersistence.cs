using System.Threading.Tasks;
using DETRAN.Domain.Entities;

namespace DETRAN.Persistence.Interface
{
    public interface IDetranPersistence
    {
        //GERAL
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();

        //CONDUTOR
        Task<Condutor[]> GetAllCondutoresByAsync(string condutor, bool includeVeiculo);
        Task<Condutor[]> GetAllCondutoresAsync(bool includeVeiculo);
        Task<Condutor> GetCondutorByIdAsync(int CondutorId, bool includeVeiculo);

        //VEICULO
        Task<Veiculo[]> GetAllVeiculosByCondutorAsync(string Veiculo, bool includeCondutor);
        Task<Veiculo[]> GetAllVeiculoesCondutorAsync(bool includeCondutor);
        Task<Veiculo> GetVeiculoByIdAsync(int VeiculoId, bool includeCondutor);
    }
}