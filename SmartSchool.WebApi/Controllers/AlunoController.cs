using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Data;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        private readonly SmartContext _smartContext;
        public AlunoController(SmartContext smartContext)
        {
            _smartContext = smartContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_smartContext.Alunos);
        }
    }
}