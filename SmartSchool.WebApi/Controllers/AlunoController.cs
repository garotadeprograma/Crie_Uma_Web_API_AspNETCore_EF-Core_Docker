using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

GCNotificationStatus         public AlunoController()
        {
            
        }

        public IActionResult Get()
        {
            return Ok("Alunos: Rafa, Paula, Mateus");
        }
    }
}