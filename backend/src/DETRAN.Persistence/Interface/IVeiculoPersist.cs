using System.Threading.Tasks;
using DETRAN.Domain.Entities;

namespace DETRAN.Persistence.Interface
{
    public interface IVeiculoPersist
    {

        Task<Veiculo[]> GetAllVeiculosByCondutorAsync(string marca, bool includeCondutor);
        Task<Veiculo[]> GetAllVeiculosAsync(bool includeCondutor);
        Task<Veiculo> GetVeiculoByIdAsync(int VeiculoId, bool includeCondutor);
    }
}