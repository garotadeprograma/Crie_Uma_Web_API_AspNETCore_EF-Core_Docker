using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Data
{
    public class Repository : IRepository
    {
        public readonly SmartContext _context;
        
        public Repository(SmartContext context)
        {
            _context = context;            
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAlunos(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAlunoByName(string alunoName, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                            .OrderBy(a => a.Id)
                            .Where(aluno => aluno.Nome == alunoName || aluno.SobreNome == alunoName); 

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                            .OrderBy(a => a.Id)
                            .Where(aluno => aluno.Id == alunoId); 

            return query.FirstOrDefault();
        }

        public Professor[] GetProfessores(bool incluirAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(incluirAluno)
            {
                query = query.Include(p => p.Disciplinas)
                                .ThenInclude(d => d.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor[] GetProfessoresByName(string professorName, bool incluirAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(incluirAluno)
            {
                query = query.Include(p => p.Disciplinas)
                                .ThenInclude(d => d.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool incluirAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(incluirAluno)
            {
                query = query.Include(p => p.Disciplinas)
                                .ThenInclude(d => d.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.FirstOrDefault();
        }
    }
}