using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApi.Models
{
    public class Artista
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        //public int album_id { set; get; }
    }
}
