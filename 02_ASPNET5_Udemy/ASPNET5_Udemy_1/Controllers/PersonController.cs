﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET5_Udemy_1.Model;
using ASPNET5_Udemy_1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ASPNET5_Udemy_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;
        private IPersonService _personService;

        public CalculatorController(ILogger<CalculatorController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetFindAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetFindByID(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult PostCreate([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult PutUpdate([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
