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
    public class ArtistaController : Controller
    {
        public readonly EstudioDbContext _estudioDbContext;
        
        public ArtistaController(EstudioDbContext estudioDbContext)
        {
            this._estudioDbContext = estudioDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioDbContext.Artistas.ToList());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}",Name ="getArtista")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_estudioDbContext.Artistas.Find(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Artista artista)
        {
            try
            {
                _estudioDbContext.Artistas.Add(artista);
                _estudioDbContext.SaveChanges();
                return Ok(artista);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put( [FromBody] Artista artista)
        {

            try
            {
                _estudioDbContext.Artistas.Update(artista);
                _estudioDbContext.SaveChanges();
                return Ok(artista);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var artista = _estudioDbContext.Artistas.Find(id);
                _estudioDbContext.Artistas.Remove(artista);
                _estudioDbContext.SaveChanges();
                return Ok(artista);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
