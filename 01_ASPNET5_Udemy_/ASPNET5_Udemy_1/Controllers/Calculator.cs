 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ASPNET5_Udemy_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumerics(firstNumber) && IsNumerics(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input!");
        }



        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumerics(firstNumber) && IsNumerics(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult GetMulti(string firstNumber, string secondNumber)
        {
            if (IsNumerics(firstNumber) && IsNumerics(secondNumber))
            {
                var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multi.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("divi/{firstNumber}/{secondNumber}")]
        public IActionResult GetMDivi(string firstNumber, string secondNumber)
        {
            if (IsNumerics(firstNumber) && IsNumerics(secondNumber))
            {
                var divi = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(divi.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}/{threeNumber}")]
        public IActionResult GetMedia(string firstNumber, string secondNumber, string threeNumber)
        {
            if (IsNumerics(firstNumber) && IsNumerics(secondNumber) && IsNumerics(threeNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) + ConvertToDecimal(threeNumber))/3;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("sqtr/{firstNumber}")]
        public IActionResult GetSqrt(string firstNumber)
        {
            if (IsNumerics(firstNumber))
            {
                var raiz =Math.Sqrt(ConvertToDouble(firstNumber));
                return Ok(raiz.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        private bool IsNumerics(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
            throw new NotImplementedException();
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doublelValue;

            if (double.TryParse(strNumber, out doublelValue))
            {
                return doublelValue;
            }

            return 0;
        }

    }
}
