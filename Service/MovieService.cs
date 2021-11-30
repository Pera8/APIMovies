using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Mapper;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class MovieService : IRepository<Movie>
    {
        private readonly IRepository<Movie> repositoryMovie;
        private readonly IRepository<Actor> repositoryActor;
        private readonly IRepository<Genre> repositoryGenre;

        static MovieService()
        {
            MapperConfig.RegisterMovieMapping();
        }
        public MovieService(IRepository<Movie> repositoryMovie, IRepository<Actor> repositoryActor, IRepository<Genre> repositoryGenre)
        {
            this.repositoryMovie = repositoryMovie;
            this.repositoryActor = repositoryActor;
            this.repositoryGenre = repositoryGenre;
        }
        public async Task<Movie> AddAsync(MovieDTO model)
        {
            if (model == null)
            {
                throw new Exception("Movie can not be null");
            }
            var modelMovie = TypeAdapter.Adapt<MovieDTO, Movie>(model);

            return await repositoryMovie.AddAsync(modelMovie);
        }

        public Task<Movie> AddAsync(Movie model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id can not be null");
            }
            await repositoryMovie.DeleteAsync(id);
        }

        public async Task<DbSet<Movie>> GetAllAsync()
        {
            return await repositoryMovie.GetAllAsync();
        }

        public async Task<Movie> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id can not be null");
            }
            return await repositoryMovie.GetAsyncById(id);
        }

        //public async Task<ActorMovie> AddActorMovieAsync(int MovieId, int ActorId)
        //{
        //    if(MovieId <1 || ActorId < 1)
        //    {
        //        throw new Exception("Id can not be null");
        //    }


        //}

        public async Task<List<Movie>> GetAllMovieByOneActor(int id)
        {
            try
            {

                var result = await repositoryMovie.GetAllAsync();
                return await result.Include(x => x.ActorMovies).Where(x => x.ActorMovies.Any(y => y.ActorsId == id)).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Actor>> GetAllActorsByOneMovie(int id)
        {
            var result = await repositoryActor.GetAllAsync();
            return await result.Include(x => x.ActorMovies).Where(x => x.ActorMovies.Any(y => y.MovieId == id)).ToListAsync();
        }

        public async Task<List<GenreDTO>> GetAllGenreByOneActor(int id)
        {
            try
            {
                var result = await repositoryMovie.GetAllAsync();
                var listGenre = await result.SelectMany(movie => movie.ActorMovies)
                    .Where(actorMovie => actorMovie.ActorsId == id)
                    .SelectMany(_actorMovie => _actorMovie.Movie.GenreMovies)
                    .Select(generMovie => generMovie.Genre).ToListAsync();

                 var genreList=  result.Where(movie => movie.ActorMovies.Any(actorMovie => actorMovie.ActorsId == id))
                    .SelectMany(movie => movie.GenreMovies.Select(genreMovie => genreMovie.Genre)).Distinct().ToList();

                
              
                List<GenreDTO> genreListDto = new List<GenreDTO>();

                for (int i = 0; i < genreList.Count; i++)
                {
                    var _genreDto = new GenreDTO()
                    {
                        Id = genreList[i].Id,
                        Name = genreList[i].Name
                    };
                    genreListDto.Add(_genreDto);
                }


                return genreListDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<ActorDTO>> GetAllActorByOneGenre(int id)
        {
            try
            {
                var _movie = await repositoryMovie.GetAllAsync();
                var actorList = _movie.Where(genre => genre.GenreMovies.Any(genreMovie => genreMovie.GenreId == id))
                    .SelectMany(movie => movie.ActorMovies.Select(actorMovie => actorMovie.Actor)).ToList();
                List<ActorDTO> actorDTOs = new List<ActorDTO>();

                for (int i = 0; i < actorList.Count; i++)
                {
                    var _actorDto = new ActorDTO()
                    {
                        Id = actorList[i].Id,
                        Name = actorList[i].Name,
                        LastName = actorList[i].LastName
                    };
                    actorDTOs.Add(_actorDto);
                }

                return actorDTOs;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
