﻿using ApiFilme.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilme.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) 
        {
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
