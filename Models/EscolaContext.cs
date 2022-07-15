using Microsoft.EntityFrameworkCore;

namespace Aula30.Models
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstituicaoModel>()
                .ToTable("Instituicoes")
                .HasKey(t => t.Id);

            modelBuilder.Entity<AlunoModel>()
                .ToTable("Alunos")
                .HasKey(t => t.Id);

            modelBuilder.Entity<InstituicaoModel>()
                .HasMany(t => t.Aluno);

        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<InstituicaoModel> Instituicoes { get; set; }
    }

}
