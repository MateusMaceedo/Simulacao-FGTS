using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimulacaoEmprestimoFGTS.Api.Contract;
using SimulacaoEmprestimoFGTS.Core.Dto.PRICE;
using SimulacaoEmprestimoFGTS.Core.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace SimulacaoEmprestimoFGTS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PRICEController : ControllerBase, IPRICEContract
    {
        private readonly ILogger<PRICEController> _logger;
        private readonly IPriceService _service;

        public PRICEController(ILogger<PRICEController> logger, IPriceService service)
        {
            _logger = logger;
            _service = service;
        }

        [Route("SimulacaoDetalhadaByEmprestimo")]
        [HttpGet]
        public ActionResult<IEnumerable<SimulacaoPriceDto>> GetSimulacaoPriceDetalhadaEmprestimo(decimal valorEmprestimo, double taxaMensal, int prazo)
        {
            _logger.LogInformation($"{MethodBase.GetCurrentMethod().Name} - ValorEmprestimo:{valorEmprestimo}, TaxaMensal:{taxaMensal}, Prazo:{prazo}");
            var simulacao = _service.GetSimulacaoPriceDetalhadaEmprestimo(valorEmprestimo, taxaMensal, prazo);
            return Ok(simulacao);
        }


        [Route("SimulacaoDetalhadaByParcela")]
        [HttpGet]
        public ActionResult<IEnumerable<SimulacaoPriceDto>> GetSimulacaoPriceDetalhadaParcela(decimal valorParcela, double taxaMensal, int prazo)
        {
            _logger.LogInformation($"{MethodBase.GetCurrentMethod().Name} - ValorParcela:{valorParcela}, TaxaMensal:{taxaMensal}, Prazo:{prazo}");
            var simulacao = _service.GetSimulacaoPriceDetalhadaParcela(valorParcela, taxaMensal, prazo);
            return Ok(simulacao);
        }


        [Route("ResumoByEmprestimo")]
        [HttpGet]
        public ActionResult<ResumoPriceDto> GetSimulacaoPriceResumidaEmprestimo(decimal valorEmprestimo, double taxaMensal, int prazo)
        {
            _logger.LogInformation($"{MethodBase.GetCurrentMethod().Name} - ValorEmprestimo:{valorEmprestimo}, TaxaMensal:{taxaMensal}, Prazo:{prazo}");
            var simulacao = _service.GetSimulacaoPriceResumidaEmprestimo(valorEmprestimo, taxaMensal, prazo);
            return Ok(simulacao);
        }

        [Route("ResumoByParcela")]
        [HttpGet]
        public ActionResult<ResumoPriceDto> GetSimulacaoPriceResumidaParcela(decimal valorParcela, double taxaMensal, int prazo)
        {
           
            _logger.LogInformation($"{MethodBase.GetCurrentMethod().Name} - ValorParcela:{valorParcela}, TaxaMensal:{taxaMensal}, Prazo:{prazo}");
            var simulacao = _service.GetSimulacaoPriceResumidaParcela(valorParcela, taxaMensal, prazo);
            return Ok(simulacao);
        }
    }
}
