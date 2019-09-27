using MyMDB.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MyMDB.Core.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using MyMDB.Core.DB;

namespace MyMDB.Core.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private List<ViewModelBase> _ViewModels;
        public enum ViewModels
        {
            LandingPage,
            Results
        }

        public MainWindowViewModel()
        {
            ListViewModels.Add(new LandingPageViewModel());
            CurrentViewModel = _ViewModels[0];  //landing page

            MessengerInstance.Register<NotificationMessage<string>>(this, MessageHandle);
        }

        private void MessageHandle(NotificationMessage<string> obj)
        {
            switch (obj.Notification)
            {
                case "GoToResults":
                    SwitchViewModel(ViewModels.Results);        //here
                    MessengerInstance.Send(new NotificationMessage<string>(obj.Content, "ResultsViewModel"));
                    break;
                case "GoToLanding":
                    SwitchViewModel(ViewModels.LandingPage);        //here
                    MessengerInstance.Send(new NotificationMessage<string>(obj.Content, "LandingPageViewModel"));
                    break;
                default:
                    //reload main page, show error
                    break;
            }
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                    _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public List<ViewModelBase> ListViewModels
        {
            get
            {
                if (_ViewModels == null)
                    _ViewModels = new List<ViewModelBase>();

                return _ViewModels;
            }
        }

        public void SwitchViewModel(ViewModels type)
        {
            switch (type)
            {
                case ViewModels.Results:
                    if (!_ViewModels.OfType<ResultsViewModel>().Any())
                    {
                        _ViewModels.Add(new ResultsViewModel());
                    }
                    CurrentViewModel = _ViewModels.FirstOrDefault(vm => vm is ResultsViewModel);                
                    break;

                case ViewModels.LandingPage:
                    if (!_ViewModels.OfType<LandingPageViewModel>().Any())
                    {
                        _ViewModels.Add(new LandingPageViewModel());
                    }
                    CurrentViewModel = _ViewModels.FirstOrDefault(vm => vm is LandingPageViewModel);
                    break;
            }
        }
    }
}
