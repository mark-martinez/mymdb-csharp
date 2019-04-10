using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Heimdall.API;
using Heimdall.Core.Model;

namespace Heimdall.Core
{
    public class APICaller
    {
        Configuration Configuration = Configuration.Instance;
        static HttpWebRequest apiRequest;
        enum ImageType { backdrop, poster };

        public static string Call(string URL, string parameters)
        {
            apiRequest = WebRequest.Create(URL + parameters) as HttpWebRequest;

            string apiResponse = "";
            try
            {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
            } catch (WebException e) {
                return "";
            }
            return apiResponse;
        }

        /// <summary>
        /// Call this method to update Configuration settings from TMDB.
        /// </summary>
        /// <param name="config">Configuration Model</param>
        public static void UpdateConfiguration()
        {
            string resp = Call("https://api.themoviedb.org/3/configuration?", "api_key=1a9755b22a226ad22bb40fc91e9ed04a"); //replace with prop reader
            Configuration.Set = JsonConvert.DeserializeObject<ConfigurationModel>(resp) as ConfigurationModel;
        }

        /*
        public static string GrabImage(string parameters, ImageType type)
        {
            string url = App.Current.Resources["Configuration"];
            if (type == ImageType.backdrop)
            {
                return "";
            }
        }
        */
    }
}
