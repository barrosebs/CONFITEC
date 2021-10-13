using System.Threading.Tasks;
using DETRAN.Domain.Entities;

namespace DETRAN.Application.Services.Interface
{
    public interface IVeiculoService
    {
        Task<Veiculo> AddVeiculo(Veiculo model);
        Task<Veiculo> UpdateVeiculo(int VeiculoId, Veiculo model);
        Task<bool> DeleteVeiculo(int VeiculoId);

        Task<Veiculo[]> GetAllVeiculoesByCondutorAsync(string Veiculo, bool includeCondutor = false);
        Task<Veiculo[]> GetAllVeiculoesAsync(bool includeCondutor = false);
        Task<Veiculo> GetVeiculoByIdAsync(int CondutorId, bool includeCondutor = false);
    }
}