using Mapster;
using Repository.Models;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public static class MapperConfig
    {
        public static void RegisterActorMapping()
        {
            TypeAdapterConfig<Actor, ActorDTO>.NewConfig();
            TypeAdapterConfig<ActorDTO, Actor>.NewConfig();
        }        

        public static void RegisterMovieMapping()
        {
            TypeAdapterConfig<Movie, MovieDTO>.NewConfig();
            TypeAdapterConfig<MovieDTO, Movie>.NewConfig();
        }        

        public static void RegisterGenreMapping()
        {
            TypeAdapterConfig<Genre, GenreDTO>.NewConfig();
            TypeAdapterConfig<GenreDTO, Genre>.NewConfig();
        }
    }
}
