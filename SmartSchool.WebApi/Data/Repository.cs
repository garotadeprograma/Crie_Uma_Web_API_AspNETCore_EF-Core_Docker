using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Aluno[] GetAlunos()
        {
            throw new NotImplementedException();
        }

        public Aluno[] GetAlunoByName()
        {
            throw new NotImplementedException();
        }

        public Aluno GetAlunoById()
        {
            throw new NotImplementedException();
        }

        public Professor[] GetProfessores()
        {
            throw new NotImplementedException();
        }

        public Professor[] GetProfessoresByName()
        {
            throw new NotImplementedException();
        }

        public Professor GetProfessorById()
        {
            throw new NotImplementedException();
        }
    }
}