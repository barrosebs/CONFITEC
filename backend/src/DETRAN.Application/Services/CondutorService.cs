using System;
using System.Threading.Tasks;
using DETRAN.Application.Services.Interface;
using DETRAN.Domain.Entities;
using DETRAN.Persistence.Interface;

namespace DETRAN.Application.Services
{
    public class CondutorService : ICondutorService
    {
        private readonly IAllPersist _allPersister;
        private readonly ICondutorPersist _condutorPersister;

        public CondutorService(IAllPersist allPersister, ICondutorPersist condutorPersister)
        {
            _allPersister = allPersister;
            _condutorPersister = condutorPersister;
        }
        public async Task<Condutor> AddCondutor(Condutor model)
        {
            try
            {
                 _allPersister.Add<Condutor>(model);
                 if (await _allPersister.SaveChangesAsync())
                 {
                     return await _condutorPersister.GetCondutorByIdAsync(model.CondutorId, false);
                 }
                 return null; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Condutor> UpdateCondutor(int condutorId, Condutor model)
        {
            try
            {
                 var condutor = await _condutorPersister.GetCondutorByIdAsync(condutorId, false);
                 if(condutor == null) return null;

                 model.CondutorId = condutorId;

                 _allPersister.Update(model);
                 if (await _allPersister.SaveChangesAsync())
                 {
                     return await _condutorPersister.GetCondutorByIdAsync(model.CondutorId, false);
                 } 
                 return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCondutor(int condutorId)
        {
            try
            {
                 var condutor = await _condutorPersister.GetCondutorByIdAsync(condutorId, false);
                 if(condutor == null) throw new Exception("Condutor não localizado");

                 _allPersister.Delete<Condutor>(condutor);

                 return await _allPersister.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Condutor[]> GetAllCondutoresAsync(bool includeVeiculo = false)
        {
            try
            {
                 var condutor = await _condutorPersister.GetAllCondutoresAsync(includeVeiculo);
                 if(condutor == null) return null;
                 
                 return condutor;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Condutor[]> GetAllCondutoresByVeiculoAsync(string condutor, bool includeVeiculo = false)
        {
            try
            {
                 var _condutor = await _condutorPersister.GetAllCondutoresByVeiculoAsync(condutor, includeVeiculo);
                 if(_condutor == null) return null;
                 
                 return _condutor;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<Condutor> GetCondutorByIdAsync(int condutorId, bool includeVeiculo = false)
        {
            try
            {
                 var _condutor = await _condutorPersister.GetCondutorByIdAsync(condutorId, includeVeiculo);
                 if(_condutor == null) return null;
                 
                 return _condutor;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}