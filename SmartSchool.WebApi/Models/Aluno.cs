namespace SmartSchool.WebApi.Models
{
    public class Aluno
    {
        public Aluno() {}

        public Aluno(int Id, string Nome, string SobreNome, string Telefone)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.SobreNome = SobreNome;
            this.Telefone = Telefone;
        }
        
        public int Id { get; set; }        

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Telefone { get; set; }
    }
}