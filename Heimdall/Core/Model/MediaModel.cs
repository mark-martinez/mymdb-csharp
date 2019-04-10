using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Core.Model
{
    public class MediaModel : IMedia
    {
        public int id { get; set; }
        public string title { get; set; }
        public string imdb_id { get; set; }
        public string overview { get; set; }
        public string backdrop_path { get; set; }
        public string poster_path { get; set; }
        public int runtime { get; set; }
        public double vote_average { get; set; }
        public string release_date { get; set; }
        public List<Genre> genres { get; set; }
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
