using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Core.Model
{
    interface IMedia
    {
        //pulled from tmdb
        int id { get; set; }
        string title { get; set; }
        string imdb_id { get; set; }
        string overview { get; set; }
        string backdrop_path { get; set; }
        string poster_path { get; set; }
        int runtime { get; set; }
        double vote_average { get; set; }
        string release_date { get; set; }
        List<Genre> genres { get; set; }
        string tagline { get; set; }
        //pulled from omdb
        string Actors { get; set; }     
        List<string> Actor { get; set; }
        List<Rating> Ratings { get; set; }
    }
}
