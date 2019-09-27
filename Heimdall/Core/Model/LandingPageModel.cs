using Newtonsoft.Json;
using MyMDB.Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyMDB.Core.Model
{
    public class LandingPageModel
    {
        //private string _BackgroundUrl;
        private BitmapImage _Background;

        public LandingPageModel()
        {
            Media obj = new Media();
            string response = APICaller.Call("https://api.themoviedb.org/3/tv/1399?api_key=1a9755b22a226ad22bb40fc91e9ed04a", "");
            //should move this to viewmodel?

            try
            {
                obj = JsonConvert.DeserializeObject<Media>(response);
                Background = new BitmapImage(new Uri("https://image.tmdb.org/t/p/original/" + obj.backdrop_path));
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.StackTrace);
                //Background = set placeholder
            }
        }

        public BitmapImage Background
        {
            get { return _Background; }
            set { _Background = value; }
        }
    }
}
