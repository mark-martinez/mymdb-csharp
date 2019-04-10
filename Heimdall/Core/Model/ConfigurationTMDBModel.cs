using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Core.Model
{
    public class ConfigurationModel
    {
        public Images Images { get; set; }
    }

    public class Images
    {
        public string base_url { get; set; }
        public string secure_base_url { get; set; }
        public List<string> backdrop_sizes { get; set; }
        public List<string> logo_sizes { get; set; }
        public List<string> poster_sizes { get; set; }
        public List<string> profile_sizes { get; set; }
        public List<string> still_sizes { get; set; }
    }
}
