using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Heimdall.Core.Model;
using Heimdall.Core.ViewModel;
using Newtonsoft.Json;

namespace Heimdall.Core.ViewModel
{
    public class ResultsViewModel : ViewModelBase
    {
        public ResultsViewModel()
        {
            ResultsModel obj = new ResultsModel();
            
            try
            {
                string response = APICaller.Call("https://api.themoviedb.org/3/search/movie?api_key=1a9755b22a226ad22bb40fc91e9ed04a", "&query=harry+potter");
                obj = JsonConvert.DeserializeObject<ResultsModel>(response);
                Console.WriteLine(response);
                Resp = response;
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public string Resp { get; set; }

    }
}
