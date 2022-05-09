using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Data;
using SmartSchool.WebApi.Models;

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

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int Id)
        {
            var aluno = _smartContext.Alunos.FirstOrDefault(a => a.Id == Id);
            if (aluno == null) return BadRequest("Id não corresponde ao de nenhum aluno!");
            
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var alunos = _smartContext.Alunos.Where(a => a.Nome.Contains(nome) || a.SobreNome.Contains(nome));

            if(alunos == null) return BadRequest("Não há nenhum aluno com o nome informado");
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            var alunoExist = _smartContext.Alunos.FirstOrDefault(a => a.Id == aluno.Id);

            if(alunoExist == null) 
            {
                _smartContext.Add(aluno);
            }
            else
            {
                alunoExist.Telefone = aluno.Telefone;
                _smartContext.Update(alunoExist);
            }

            _smartContext.SaveChanges();
            return Ok(_smartContext.Alunos);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Aluno aluno)
        {
            var alunoExist = _smartContext.Alunos.FirstOrDefault(a => a.Id == aluno.Id);
            if(alunoExist == null) return BadRequest("Aluno não encontrado");

            _smartContext.Remove(alunoExist);
            _smartContext.SaveChanges();
            return Ok(_smartContext.Alunos);
        }
    }
}