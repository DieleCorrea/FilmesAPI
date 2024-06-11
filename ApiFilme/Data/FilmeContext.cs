using ApiFilme.Models;
using ApiFilme.Models.Flmes;
using Microsoft.EntityFrameworkCore;

namespace ApiFilme.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) 
        {
        }
        //Aqui eu defino como vai ser costruido o  relacionamento de sessao e cinema, sessao e filme e como o ID vai ser montado os dois em um. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessao>()
                .HasKey(sessao => new {sessao.FilmeId, sessao.CinemaId});

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);


            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .OnDelete(DeleteBehavior.Restrict);//não permite deletar, pois faz a deleção em cascata, e isso acarretaria em deletar o cinema e consequentimente a sessão 
        }

        // para criar a tabela no banco 
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }  
        public DbSet<HorasTrabalhadas> HorasTrabalhadas { get; set; }   
    }
}
