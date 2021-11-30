using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Movie : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GenreMovie> GenreMovies { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
