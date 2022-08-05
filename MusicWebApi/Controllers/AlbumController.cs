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
    public class AlbumController : Controller
    {
        public readonly EstudioDbContext _estudioDbContext;

        public AlbumController(EstudioDbContext estudioDbContext)
        {
            this._estudioDbContext = estudioDbContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_estudioDbContext.Albums.ToList());
                
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}",Name ="getAlbum")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_estudioDbContext.Albums.Find(id));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Album album)
        {
            try
            {
                _estudioDbContext.Albums.Add(album);
                _estudioDbContext.SaveChanges();
                return Ok(album);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Album album)
        {
            try
            {
                _estudioDbContext.Albums.Update(album);
                _estudioDbContext.SaveChanges();
                return Ok(album);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var album = _estudioDbContext.Albums.Find(id);
                _estudioDbContext.Albums.Remove(album);
                _estudioDbContext.SaveChanges();
                return Ok(album);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
