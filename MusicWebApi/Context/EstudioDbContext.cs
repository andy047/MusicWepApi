using Microsoft.EntityFrameworkCore;
using MusicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApi.Context
{
    public class EstudioDbContext:DbContext
    {
        public EstudioDbContext(DbContextOptions<EstudioDbContext> options) : base(options)
        {

        }

        public DbSet <Album> Albums { set; get; }
        public DbSet<Artista> Artistas { set; get; }
        public DbSet<Cancion> Canciones { set; get; }

    }
}
