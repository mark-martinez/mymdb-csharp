using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Heimdall.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Heimdall.Core.ViewModel
{
    public class ResultsViewModel : ViewModelBase
    {
        private ObservableCollection<Result> _listResults;
        private BitmapImage _background;
        private ICommand _submitInputCommand;
        private ResultsModel _resultsModel;

        public ResultsViewModel()
        {
            _resultsModel = new ResultsModel();

            MessengerInstance.Register<NotificationMessage<string>>(this, m =>
            {
                if (m.Notification.Equals("ResultsViewModel")) MessageHandle(m.Content);                
            });
        }

        public ObservableCollection<Result> ListResults
        {
            get
            {
                if (_listResults == null)
                    _listResults = new ObservableCollection<Result>();
                return _listResults;
            }
        }

        private void MessageHandle(string message)
        {
            //validate input
            CallToApi(message);
        }

        public BitmapImage ImageBackground
        {
            get { return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged("ImageBackground");
            }
        }

        /*
         * make async
         */
        private void CallToApi(string query)
        {
            try
            {
                string response = APICaller.Call("https://api.themoviedb.org/3/search/movie?api_key=1a9755b22a226ad22bb40fc91e9ed04a", "&query=" + query);
                _resultsModel = JsonConvert.DeserializeObject<ResultsModel>(response);
                Console.WriteLine("response here: " + response);
                Console.WriteLine("results model: " + _resultsModel.results.Count);

                ImageBackground = new BitmapImage(new Uri("https://image.tmdb.org/t/p/original/" + _resultsModel.results[0].backdrop_path));

                _resultsModel.results.ForEach(delegate (Result s)
                {
                    ListResults.Add(s);
                });
                RaisePropertyChanged("ListResults");
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        /**
         * temporary method may not keep here
         */
        public ICommand ReturnToLanding
        {
            get
            {
                return _submitInputCommand ?? (_submitInputCommand = new RelayCommand(() =>
                {
                    MessengerInstance.Send(new NotificationMessage<string>("SendMeBack", "GoToLanding"));
                    _resultsModel = null;
                    ListResults.Clear();
                    RaisePropertyChanged("ListResults");
                }
                ));
            }
        }
    }
}
