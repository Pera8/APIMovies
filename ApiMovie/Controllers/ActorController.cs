using Microsoft.AspNetCore.Mvc;
using Service;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovie.Controllers
{
    [Route("api/Actor")]
    public class ActorController : Controller
    {
        private readonly ActorService actorService;
        public ActorController(ActorService actorService)
        {
            this.actorService = actorService;
        }

        [HttpPost]
        public async Task<ActionResult> AddActor(ActorDTO actorDTO)
        {
            return Ok(await actorService.AddAsync(actorDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllActor()
        {
            return Ok(await actorService.GetAllAsync());
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetActorById(int id)
        {
            return Ok(await actorService.GetAsyncById(id));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteActor(int id)
        {
            await actorService.DeleteAsync(id);
            return Ok();
        }
    }
}
