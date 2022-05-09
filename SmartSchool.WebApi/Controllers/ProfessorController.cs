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

         [HttpGet("byId/{id}")]
        public IActionResult GetById(int Id)
        {
            var _professor = _smartContext.Professores.FirstOrDefault(p => p.Id == Id);
            if (_professor == null) return BadRequest("Id não corresponde ao de nenhum aluno!");
            
            return Ok(_professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var _professores = _smartContext.Professores.Where(p => p.Nome.Contains(nome));

            if(_professores == null) return BadRequest("Não há nenhum aluno com o nome informado");
            return Ok(_professores);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            var _professor = _smartContext.Professores.FirstOrDefault(p => p.Id == professor.Id);

            if(_professor == null)
            {
                _smartContext.Add(_professor);
            }
            else
            {
                _professor.Nome = professor.Nome;                
                _smartContext.Update(_professor);
            }

            return Ok("Alterações concluídas com sucesso!");
        }

        [HttpPost]
        public IActionResult Delete(Professor professor)
        {
            var _professor = _smartContext.Professores.FirstOrDefault(p => p.Id == professor.Id);

            if(_professor == null) return BadRequest("Registro não encontrado");
            
            _smartContext.Add(_professor);            

            return Ok("Registro excluído com sucesso");
        }
    }
}