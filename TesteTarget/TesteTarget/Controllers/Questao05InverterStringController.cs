using Microsoft.AspNetCore.Mvc;

namespace InverterStringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Questao05InverterStringController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Post([FromBody] string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("A string não pode ser nula ou vazia.");
            }

            
            var resultado = InverterString(input);

            return Ok(new { Original = input, Invertida = resultado });
        }

        private string InverterString(string str)
        {
            char[] caracteres = str.ToCharArray();
            int esquerda = 0;
            int direita = caracteres.Length - 1;

            while (esquerda < direita)
            {
               
                char temp = caracteres[esquerda];
                caracteres[esquerda] = caracteres[direita];
                caracteres[direita] = temp;
                
                esquerda++;
                direita--;
            }

            return new string(caracteres);
        }
    }
}
