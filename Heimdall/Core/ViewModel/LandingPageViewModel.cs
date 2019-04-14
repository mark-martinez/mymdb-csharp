using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Heimdall.Core.Model;
using Heimdall.Core.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace Heimdall.Core.ViewModel
{
    public class LandingPageViewModel : ViewModelBase
    {
        private ICommand _submitInputCommand;
        private LandingPageModel _LandingPageModel;
        public string _textInput = "What are we watching today?";

        public LandingPageViewModel()
        {
            _LandingPageModel = new LandingPageModel();
            MessengerInstance.Register<NotificationMessage<string>>(this, m =>
            {
                if (m.Notification.Equals("LandingPageViewModel")) DoNothing(m.Content);
            });
        }

        private void DoNothing(string message)
        {
        }

        public BitmapImage ImageBackground
        {
            get { return _LandingPageModel.Background; }
        }

        public string TextInput
        {
            get { return _textInput; }
            set
            {
                _textInput = value;
                RaisePropertyChanged("TextInput");
            }
        }

        public ICommand SubmitInputCommand
        {
            get
            {
                return _submitInputCommand ?? (_submitInputCommand = new RelayCommand(() =>
                {
                    MessengerInstance.Send(new NotificationMessage<string>(TextInput, "GoToResults"));
                }
                ));
            }
        }
    }
}
