using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DETRAN.Domain.Entities
{
    public class Condutor
    {
        public int CondutorId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string NumeroCnh { get; set; }
        public DateTime DataNacimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public int VeiculoId { get; set; }
        public virtual IEnumerable<CondutorVeiculo> CondutorVeiculos { get; set; }


        /// <summary>
        /// O e-mail do condutor deve ser válido.
        /// </summary>
        /// <param name="condutor.DataNascimento"></param>
        /// <returns>true</returns>
        public bool CondutorMaiorIdade(Condutor condutor){
            if(condutor.DataNacimento.ToString() == null){
                return false;   
            }
            
            //A idade do condutor não pode ser menor que 18 anos, considerando a data atual e a sua data de nascimento.
            if (condutor.DataNacimento.AddYears(18) > DateTime.Now){
                return true;
            }else
                return false;
        }

        /// <summary>
        ///     CPF deve conter 11 caracteres.
        /// </summary>
        /// <param name="condutor.cpf"></param>
        /// <returns>true</returns>
        public bool CpfCondutorValido(Condutor condutor){
            if (condutor.Cpf.Length == 11)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// verifica se o e-mail é valido
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true</returns>
           public bool ValidaEmail(string email)
        {
            if (email == null)
            {
                return false;
            }

            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
                return false;
        }


    }
}
