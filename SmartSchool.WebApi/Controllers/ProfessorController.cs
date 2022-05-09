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

        
    }
}