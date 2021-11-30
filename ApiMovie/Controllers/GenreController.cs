using Microsoft.AspNetCore.Mvc;
using Service;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovie.Controllers
{
    [Route("api/Genre")]
    public class GenreController : Controller
    {
        private readonly GenreService genreService;

        public GenreController(GenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpPost]
        public async Task<ActionResult> AddGenre(GenreDTO genreDTO)
        {
            return Ok(await genreService.AddAsync(genreDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGenre()
        {
            return Ok(await genreService.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetGenreById(int id)
        {
            return Ok(await genreService.GetAsyncById(id));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await genreService.DeleteAsync(id);
            return Ok();
        }
    }
}
