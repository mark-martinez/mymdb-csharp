using System.Collections.Generic;

namespace MyMDB.Core.Model
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
        List<int> genre_ids { get; set; }
        string tagline { get; set; }
        //pulled from omdb
        string Actors { get; set; }     
        List<string> Actor { get; set; }
        List<Rating> Ratings { get; set; }
    }
}
