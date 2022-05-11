using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        bool SaveChanges();

        Aluno[] GetAlunos(bool incluirProfessor);

        Aluno[] GetAlunoByName(string alunoName, bool incluirProfessor = false);

        Aluno GetAlunoById(int alunoId, bool incluirProfessor = false);
        
        Professor[] GetProfessores(bool incluirAluno);

        Professor[] GetProfessoresByName(string professorName, bool incluirAluno = false);

        Professor GetProfessorById(int professorId, bool incluirAluno = false);
    }
}