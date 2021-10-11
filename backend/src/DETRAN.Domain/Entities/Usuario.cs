using System;

namespace DETRAN.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { get; set; }
        public DateTime UsuarioDataCadastro { get; set; }
        public bool UsuarioAtivo { get; set; }

        /// <summary>
        /// Verifica se o usuário esta ativo
        /// </summary>
        /// <param name="user.Ativo"></param>
        /// <returns>true</returns>
        public bool UsuarioIsAtivo(Usuario user)
        {
            return user.UsuarioAtivo;
        }

    }
}
