using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Core.Model
{
    public class Media : IMedia
    {
        public int id { get; set; }
        public string title { get; set; }
        //tmdB TV does not have a field "title" like movie does, only "name"
        public string name 
        {
            get
            {
                return name;
            }
            set
            {
                title = value;
            }
        }
        public string imdb_id { get; set; }
        public string overview { get; set; }
        public string backdrop_path { get; set; }
        public string poster_path { get; set; }
        public string media_type { get; set; }
        public int runtime { get; set; }
        public double vote_average { get; set; }
        public string release_date { get; set; }
        public List<int> genre_ids { get; set; } //List<GEnre>
        
        public string genre_id
        {            
            get
            {
                if (genre_ids == null)
                    return null;
                //query tmdb for int = genre
                return string.Join(", ", genre_ids.ToArray());
            }
            set
            {
                if (value == null)
                {
                    genre_ids = null;
                    return;
                }
                genre_ids = value.Split(',').Select(int.Parse).ToList();
            }            
        }
        
        public string tagline { get; set; }

        public List<string> Actor { get; set; }
        public string Actors
        {
            get
            {
                if (Actor == null)
                    return null;
                return string.Join(", ", Actor.ToArray());
            }
            set
            {
                if (value == null)
                {
                    Actors = null;
                    return;
                }
                Actor = value.Split(',').Select(s => s.Trim()).ToList<string>();
            }
        }
        public List<Rating> Ratings { get; set; }
    }
}
