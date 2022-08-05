using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicWebApi.Context;
using MusicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        public readonly EstudioDbContext _estudioDbContext;

        public CancionesController(EstudioDbContext estudioDbContext)
        {
            this._estudioDbContext = estudioDbContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_estudioDbContext.Canciones.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}", Name = "getCancion")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_estudioDbContext.Canciones.Find(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("nombre={nombre}")]
        public IActionResult Get(string nombre)
        {
            try
            {

                return Ok(_estudioDbContext.Canciones.Where(n => n.Nombre.Contains(nombre)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("all")]
        //public IActionResult GetAll()
        public async Task<ActionResult<IEnumerable<Artista>>> GetAll()
        {
            try
            {
               
                var DatosCanciones = _estudioDbContext.Artistas
                .Join(_estudioDbContext.Albums, artista => artista.Id, 
                                                album=>album.ArtistaId, 
                                                (artista,album) => new { artista,album })
                .Join(_estudioDbContext.Canciones, 
                                                albumCancion => albumCancion.album.Id, 
                                                canciones => canciones.AlbumId, (albumCancion, canciones) => new { albumCancion, canciones })
                .Select(m => new {
                    idCancion = m.canciones.Id,
                    nombreArtista = m.albumCancion.artista.Nombre,
                    apellidoArtista = m.albumCancion.artista.Apellido,
                    nombreAlbum = m.albumCancion.album.Nombre,
                    nombreCancion = m.canciones.Nombre
                });
                return Ok(DatosCanciones);
               
            /*
                return await _estudioDbContext.Set<Artista>()
                    .AsQueryable()
                    .Intersect(x => x.Albums)
                    .ThenInclude(x => x.Cancion)
                    .ToListAsync();
                */
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cancion cancion)
        {
            try
            {
                _estudioDbContext.Canciones.Add(cancion);
                _estudioDbContext.SaveChanges();
                return Ok(cancion);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cancion cancion)
        {
            try
            {
                _estudioDbContext.Canciones.Update(cancion);
                _estudioDbContext.SaveChanges();
                return Ok(cancion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cancion = _estudioDbContext.Canciones.Find(id);
                _estudioDbContext.Canciones.Remove(cancion);
                _estudioDbContext.SaveChanges();
                return Ok(cancion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
