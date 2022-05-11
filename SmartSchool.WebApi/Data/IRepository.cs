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

        Aluno[] GetAlunos();

        Aluno[] GetAlunoByName();

        Aluno GetAlunoById();
        
        Professor[] GetProfessores();

        Professor[] GetProfessoresByName();

        Professor GetProfessorById();
    }
}