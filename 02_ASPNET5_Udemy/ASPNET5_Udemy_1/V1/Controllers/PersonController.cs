 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET5_Udemy_1.Model;
using ASPNET5_Udemy_1.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ASPNET5_Udemy_1.Controllers
{
    //[ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class API_UdemyController : ControllerBase
    {

        private readonly ILogger<API_UdemyController> _logger;
        private IPersonBusiness _personBusiness;

        public API_UdemyController(ILogger<API_UdemyController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet("FindAll")]
        public IActionResult GetFindAll()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetFindByID(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost("Created")]
        public IActionResult PostCreate([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut("Update")]
        public IActionResult PutUpdate([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }
}
