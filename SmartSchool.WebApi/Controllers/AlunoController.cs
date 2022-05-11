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
        public readonly IRepository _repo;
        private readonly SmartContext _smartContext;

        public AlunoController(SmartContext smartContext,
                                IRepository repo)
        {
            _repo = repo;
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
            var _aluno = _smartContext.Alunos.FirstOrDefault(a => a.Id == aluno.Id);

            if(_aluno == null) 
            {
                _repo.Add(aluno);
            }
            else
            {
                _aluno.Telefone = aluno.Telefone;
                _repo.Update(_aluno);
            }

            if(_repo.SaveChanges())
                return Ok("Alteração concluída com sucesso!");

            return BadRequest("Alteração não foi concluída");
        }

        [HttpPost("delete")]
        public IActionResult Delete(Aluno aluno)
        {
            var _aluno = _smartContext.Alunos.FirstOrDefault(a => a.Id == aluno.Id);
            if(_aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(_aluno);
            
            if(_repo.SaveChanges())
                return Ok("Registro deletado com sucesso!");

            return BadRequest("Alteração não foi concluída");
        }
    }
}