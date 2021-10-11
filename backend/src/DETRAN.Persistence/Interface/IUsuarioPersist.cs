using System.Threading.Tasks;
using DETRAN.Domain.Entities;

namespace DETRAN.Persistence.Interface
{
    public interface IUsuarioPersist
    {

        Task<Usuario[]> GetAllUsuarioByCondutorAsync(string marca, bool includeCondutor);
        Task<Usuario[]> GetAllUsuarioAsync();
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includeCondutor);
    }
}