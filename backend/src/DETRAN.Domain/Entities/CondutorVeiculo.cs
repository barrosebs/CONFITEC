using System;
using System.Collections.Generic;
using System.Text;

namespace DETRAN.Domain.Entities
{
    public class CondutorVeiculo
    {
        public int CondutorId { get; set; }
        public virtual Condutor Condutor { get; set; }

        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}
