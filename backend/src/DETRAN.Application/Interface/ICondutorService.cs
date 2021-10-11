using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DETRAN.Domain.Entities;

namespace DETRAN.Application.Services.Interface
{
    public interface ICondutorService
    {
        Task<Condutor> AddCondutor(Condutor model);
        Task<Condutor> UpdateCondutor(int condutorId, Condutor model);
        Task<bool> DeleteCondutor(int condutorId);

        Task<Condutor[]> GetAllCondutoresByVeiculoAsync(string condutor, bool includeVeiculo = false);
        Task<Condutor[]> GetAllCondutoresAsync(bool includeVeiculo = false);
        Task<Condutor> GetCondutorByIdAsync(int CondutorId, bool includeVeiculo = false);
    }
}