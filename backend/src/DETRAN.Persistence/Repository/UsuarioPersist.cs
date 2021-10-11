using System.Linq;
using System.Threading.Tasks;
using DETRAN.Domain.Entities;
using DETRAN.Persistence.Data.Context;
using DETRAN.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace DETRAN.Persistence.Repository
{
    public class UsuarioPersist : IUsuarioPersist
    {
        private readonly DetranContext _context;
        public UsuarioPersist(DetranContext context)
        {
            _context = context;
        }

        public async Task<Usuario[]> GetAllUsuarioAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.OrderBy(u => u.UsuarioId);
            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuarioByCondutorAsync(string nome, bool includeCondutor = false)
        {
            IQueryable<Usuario> query = _context.Usuarios;
            
            if(includeCondutor){
                //implementar caso inclua condutores para um usuario específico 
            }
            query = query.OrderBy(e => e.UsuarioId).Where(c => c.UsuarioNome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includeCondutor = false)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            if(includeCondutor){
                //implementar caso inclua condutores para um usuario específico 

            }
            query = query.OrderBy(e => e.UsuarioId)
            .Where(e => e.UsuarioId == usuarioId);
            return await query.FirstOrDefaultAsync();
        }
    }
}