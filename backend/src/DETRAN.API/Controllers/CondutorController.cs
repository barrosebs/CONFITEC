using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DETRAN.Application.Services.Interface;
using DETRAN.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DETRAN.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CondutorController : Controller
    {
        private readonly ICondutorService _condutorService;

        public CondutorController(ICondutorService condutorService)
        {
            _condutorService = condutorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var condutores = await _condutorService.GetAllCondutoresAsync(true);
                if (condutores == null) return NotFound("Nenhum condutor encontrado!");
                return Ok(condutores);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar condutor. Erro {ex.Message}");
            }
        }

        
        [HttpGet("{veiculo}/veiculo")]
        public async Task<IActionResult> GetByVeiculo(string veiculo)
        {
            try
            {
                 var condutor = await _condutorService.GetAllCondutoresByVeiculoAsync(veiculo, false);
                if (condutor == null) return NotFound("veículo não encontrado!");
                return Ok(condutor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar recuperar condutor. Erro {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Condutor model)
        {
            try
            {
                 var condutor = await _condutorService.AddCondutor(model);
                if (condutor == null) return BadRequest("Erro ao tentar adicionar Condutor");
                return Ok(condutor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar adicionar condutor. Erro {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Condutor model)
        {
            try
            {
                 var condutor = await _condutorService.UpdateCondutor(id, model);
                if (condutor == null) return BadRequest("Erro ao tentar alterar Condutor");
                return Ok(condutor);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar alterar condutor. Erro {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _condutorService.DeleteCondutor(id))
                    return Ok("Deletado com sucesso!");
                else 
                    return BadRequest("Condutor não deletado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error ao tentar deletar condutor. Erro {ex.Message}");
            }
        }

    }
}