using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesteTarget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Questao04FFaturamentoMensalController : ControllerBase
    {
        // GET: api/Faturamento
        [HttpGet]
        public IActionResult Get()
        {
            
            var faturamentoPorEstado = new Dictionary<string, double>
            {
                { "SP", 67836.43 },
                { "RJ", 36678.66 },
                { "MG", 29229.88 },
                { "ES", 27165.48 },
                { "Outros", 19849.53 }
            };

            
            double valorTotal = faturamentoPorEstado.Values.Sum();

            
            var percentualPorEstado = faturamentoPorEstado.ToDictionary(
                item => item.Key,
                item => (item.Value / valorTotal) * 100
            );

            return Ok(percentualPorEstado);
        }
    }
}
