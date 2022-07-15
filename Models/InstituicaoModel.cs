namespace Aula30.Models
{
    public class InstituicaoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }
        public ICollection<AlunoModel> Aluno { get; set; } = new List<AlunoModel>();    
        
    }
    

}
