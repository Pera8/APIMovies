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
    public class GenreService : IRepository<Genre>
    {
        private readonly IRepository<Genre> repositoryGenre;

        static GenreService()
        {
            MapperConfig.RegisterGenreMapping();
        }
        public GenreService(IRepository<Genre> repositoryGenre)
        {
            this.repositoryGenre = repositoryGenre;
        }
        public async Task<Genre> AddAsync(GenreDTO model)
        {
            if (model == null)
            {
                throw new Exception("Genrt can not be null");
            }
            var modelGenre= TypeAdapter.Adapt<GenreDTO, Genre>(model);

            return await repositoryGenre.AddAsync(modelGenre);
        }

        public Task<Genre> AddAsync(Genre model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id genre can not be null");
            }
            await repositoryGenre.DeleteAsync(id);
        }

        public async Task<DbSet<Genre>> GetAllAsync()
        {
            return await repositoryGenre.GetAllAsync();
        }

        public async Task<Genre> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id genre can not be null");
            }

            return await repositoryGenre.GetAsyncById(id);
        }

        
    }
}
