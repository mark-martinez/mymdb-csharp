using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyMDB.Core.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyMDB.Core.DB;
using MyMDB.Core.View;
using System;
using System.Windows.Controls;

namespace MyMDB.Core.ViewModel
{
    public class ResultsViewModel : ViewModelBase
    {
        private ICommand _submitInputCommand;
        private ICommand _selectItemCommand;
        private ResultsReader _resultsReader;
        private ObservableCollection<ResultListing> _resultsList;

        public ResultsViewModel()
        {
            _resultsReader = new ResultsReader();
            
            MessengerInstance.Register<NotificationMessage<string>>(this, m =>
            {
                if (m.Notification.Equals("ResultsViewModel"))
                {
                    _resultsList = new ObservableCollection<ResultListing>();
                    _resultsReader.current_query = m.Content;
                    _resultsReader.Results.results.ForEach(delegate (Media s)
                    {
                        _resultsList.Add(new ResultListing(s));
                    });
                }                
            });
        }

        public ObservableCollection<ResultListing> ResultsList
        {
            get
            {
                if (_resultsList == null)
                    _resultsList = new ObservableCollection<ResultListing>();
                return _resultsList;
            }
        }

        public ICommand ReturnToLanding
        {
            get
            {
                return _submitInputCommand ?? (_submitInputCommand = new RelayCommand(() =>
                {
                    _resultsReader.Results = null;
                    ResultsList.Clear();
                    RaisePropertyChanged("ListResults");
                    MessengerInstance.Send(new NotificationMessage<string>("SendMeBack", "GoToLanding"));
                }
                ));
            }
        }

        public ICommand DatabaseContent
        {
            get
            {
                return _submitInputCommand ?? (_submitInputCommand = new RelayCommand(() =>
                {
                    MongoClient.DisplayContent();
                }
                ));
            }
        }

        public ICommand ResultClickHandler
        {
            get
            {
                return _selectItemCommand ?? (_selectItemCommand = new RelayCommand<ResultsViewModel>((data) =>
                {
                    Console.WriteLine("here: " + data);
                }
                ));
            }
        }
    }
}
