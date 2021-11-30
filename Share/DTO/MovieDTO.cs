using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
