using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovie.Controllers
{
    [Route("api/Movie")]
    public class MovieController : Controller
    {
        private readonly MovieService movieService;
        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieDTO movie)
        {
            return Ok(await movieService.AddAsync(movie));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMovie()
        {
            return Ok(await movieService.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            return Ok(await movieService.GetAsyncById(id));
        }

        [HttpGet("GetMoviesByActorId/{id}")]
        public async Task<ActionResult> GetMoviesByActorId(int id)
        {
            return Ok(await movieService.GetAllMovieByOneActor(id));
        }

        [HttpGet("GetActorsByMovieId/{id}")]
        public async Task<ActionResult> GetActorByMovieId (int id)
        {
            return Ok(await movieService.GetAllActorsByOneMovie(id));
        }

        [HttpGet("GetAllGenreByOneActor/{id}")]
        public async Task<ActionResult> GetAllGenreByOneActor(int id)
        {
            return Ok(await movieService.GetAllGenreByOneActor(id));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            await movieService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetAllActorByOneGenre/{id}")]
        public async Task<ActionResult> GetAllActorByOneGenre(int id)
        {
            return Ok(await movieService.GetAllActorByOneGenre(id));
        }
    }
}
