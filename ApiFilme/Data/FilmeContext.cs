using ApiFilme.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilme.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) 
        {
        }

        // para criar a tabela no banco 
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
