using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSchool.WebApi.Data;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _smartContext;

        public ProfessorController(SmartContext smartContext)
        {
            _smartContext = smartContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_smartContext.Professores);
        }

        

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            var professorExist = _smartContext.Professores.FirstOrDefault(p => p.Id == professor.Id);

            if(professorExist == null)
            {
                _smartContext.Add(professorExist);
            }
            else
            {
                pro
                _smartContext.Update(professorExist);
            }
            return Ok
        }
    }
}