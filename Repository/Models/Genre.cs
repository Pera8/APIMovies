using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Genre: IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GenreMovie> GenreMovies { get; set; }
    }
}
