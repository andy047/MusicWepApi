using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApi.Models
{
    public class Album
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public int ArtistaId { set; get; }
        public Artista Artista { set; get; }

    }
}
