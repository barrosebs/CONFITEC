using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DETRAN.Domain.Entities
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string AnoDeFabricacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CondutorId { get; set; }
        public virtual IEnumerable<CondutorVeiculo> VeiculoCondures { get; set; }


        /// <summary>
        /// Permitir somente cadastro de placas válidas no Brasil incluindo padrão Mercosul.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns>true</returns>
        public bool ValidaPlaca(string placa){
            if (string.IsNullOrWhiteSpace(placa)) { return false; }
            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();
            
            //Verifica se o caractere da posição 4 é uma letra, se sim, aplica a validação para o formato de placa do Mercosul,
            // senão, aplica a validação do formato de placa padrão.
            if (char.IsLetter(placa, 4))
            {
                
                // Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}
