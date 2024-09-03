using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FaturamentoApi.Models;

namespace FaturamentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Questao03FaturamentoController : ControllerBase
    {
        // GET: api/Questao03Faturamento
        [HttpGet]
        public IActionResult Get()
        {
            // Caminho para o arquivo JSON na pasta wwwroot
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "faturamento.json");

            // Leitura do arquivo JSON
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            var faturamentos = JsonSerializer.Deserialize<List<ReFaturamento>>(jsonData);

            if (faturamentos == null || !faturamentos.Any())
            {
                return NotFound("Nenhum dado de faturamento encontrado.");
            }

            // Remove dias sem faturamento (faturamento = 0)
            var diasComFaturamento = faturamentos.Where(f => f.Faturamento > 0).ToList();

            if (!diasComFaturamento.Any())
            {
                return NotFound("Nenhum dia com faturamento disponível.");
            }

            var menorFaturamento = diasComFaturamento.Min(f => f.Faturamento);
            var maiorFaturamento = diasComFaturamento.Max(f => f.Faturamento);
            var mediaMensal = diasComFaturamento.Average(f => f.Faturamento);

            var diasAcimaDaMedia = diasComFaturamento.Count(f => f.Faturamento > mediaMensal);

            return Ok(new
            {
                MenorFaturamento = menorFaturamento,
                MaiorFaturamento = maiorFaturamento,
                DiasAcimaDaMedia = diasAcimaDaMedia
            });
        }
    }
}
