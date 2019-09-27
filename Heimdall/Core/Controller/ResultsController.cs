using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyMDB.Core.API;
using MyMDB.Core.Model;
using Newtonsoft.Json;

namespace MyMDB.Core.Controller
{
    public class ResultsController
    {
        public static string CallApi(string query)
        {
            try
            {
                return APICaller.Call("https://api.themoviedb.org/3/search/multi?api_key=1a9755b22a226ad22bb40fc91e9ed04a", "&query=" + query);
                /*
                _resultsModel = JsonConvert.DeserializeObject<Results>(response);

                               
                _resultsModel.results.ForEach(delegate (Media s)
                {
                    //MongoClient.InsertResult(s);
                    ListResults.Add(s);
                });
                RaisePropertyChanged("ListResults");
                MessengerInstance.Send(new NotificationMessage<ObservableCollection<Media>>(ListResults, "NewResultsList"));
                */
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
