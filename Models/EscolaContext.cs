using Microsoft.EntityFrameworkCore;

namespace Aula30.Models
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<InstituicaoModel> Instituicoes { get; set; }
    }

}
