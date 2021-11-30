using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Mapper;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ActorService : IRepository<Actor>
    {
        private readonly IRepository<Actor> repositoryActor;

        static ActorService()
        {
            MapperConfig.RegisterActorMapping();
        }
        public ActorService(IRepository<Actor> repositoryActor)
        {
            this.repositoryActor = repositoryActor;
        }
        public async Task<Actor> AddAsync(ActorDTO model)
        {
            if (model == null)
            {
                throw new Exception("Actor can not be null");
            }
            var modelActor= TypeAdapter.Adapt<ActorDTO, Actor>(model);

            return await repositoryActor.AddAsync(modelActor);
        }

        public Task<Actor> AddAsync(Actor model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id can not be null");
            }
            await repositoryActor.DeleteAsync(id);
        }

        public async Task<DbSet<Actor>> GetAllAsync()
        {
            return await repositoryActor.GetAllAsync();
        }

        public async Task<Actor> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id can not be null");
            }
            return await repositoryActor.GetAsyncById(id);
        }

        
    }
}
