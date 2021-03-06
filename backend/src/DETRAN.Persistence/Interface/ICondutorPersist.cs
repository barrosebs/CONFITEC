using System.Threading.Tasks;
using DETRAN.Domain.Entities;

namespace DETRAN.Persistence.Interface
{
    public interface ICondutorPersist
    {
        Task<Condutor[]> GetAllCondutoresByVeiculoAsync(string condutor, bool includeVeiculo = false);
        Task<Condutor[]> GetAllCondutoresAsync(bool includeVeiculo = false);
        Task<Condutor> GetCondutorByIdAsync(int CondutorId, bool includeVeiculo = false);
    }
}