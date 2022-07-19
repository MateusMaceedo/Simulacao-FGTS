using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimulacaoEmprestimoFGTS.Api.Contract;
using SimulacaoEmprestimoFGTS.Core.Dto.SAC;
using SimulacaoEmprestimoFGTS.Core.Interfaces;
using SimulacaoEmprestimoFGTS.Domain.Model.BASE;
using System.Collections.Generic;

namespace SimulacaoEmprestimoFGTS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SACController : ControllerBase, ISACContract
    {
        private readonly ILogger<SACController> _logger;
        private readonly ISACService _service;

        public SACController(ILogger<SACController> logger, ISACService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Obter todos os usuários.
        /// </summary>
        /// <response code="200">A lista de usuários foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de usuários.</response>
        [HttpGet]
        //[ProducesResponseType(typeof(List<SimulacaoGetVm>), 200)]
        [ProducesResponseType(500)]
        [Route("ResumoSimulacao")]
        [HttpGet]
        public ActionResult<ResumoSACDto> GetResumoSimulacaoSAC(decimal valorEmprestimo, double taxaMensal, int prazo)
        { 
           _logger.LogInformation($"Resumo SAC - ValorEmprestimo:{valorEmprestimo}, TaxaMensal:{taxaMensal}, Prazo:{prazo}");
           var resumo = _service.GetSimulacaoResumida(valorEmprestimo, taxaMensal, prazo);
           return Ok(resumo); 
        }

        /// <summary>
        /// Obter todos os usuários.
        /// </summary>
        /// <response code="200">A lista de usuários foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de usuários.</response>
        [HttpGet]
        //[ProducesResponseType(typeof(List<SimulacaoGetVm>), 200)]
        [ProducesResponseType(500)]
        [Route("SimulacaoDetalhada")]
        [HttpGet]
        public ActionResult<IEnumerable<SimulacaoSACDto>> GetSimulacaoSAC(decimal valorEmprestimo, double taxaMensal, int prazo)
        {
            _logger.LogInformation($"Resumo SAC - ValorEmprestimo:{valorEmprestimo}, TaxaMensal:{taxaMensal}, Prazo:{prazo}");
            var simulacao = _service.GetSimulacaoDetalhada(valorEmprestimo, taxaMensal, prazo);
            return Ok(simulacao);
        }
    }
}
