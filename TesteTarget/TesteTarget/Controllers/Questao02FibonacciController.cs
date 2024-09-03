using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesteTarget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Questao02FibonacciController : ControllerBase
    {
        
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            bool isFibonacci = IsInFibonacciSequence(number);

            if (isFibonacci)
            {
                return Ok(new { Message = $"{number} pertence a sequência de Fibonacci." });
            }
            else
            {
                return Ok(new { Message = $"{number} não pertence a sequência de Fibonacci." });
            }
        }

        private bool IsInFibonacciSequence(int number)
        {
            if (number < 0) return false;

            int previous = 0;
            int current = 1;

            while (current <= number)
            {
                if (current == number) return true;

                int next = previous + current;
                previous = current;
                current = next;
            }

            return false;
        }
    }
}
