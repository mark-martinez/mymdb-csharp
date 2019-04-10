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
using Heimdall.Core.Command;

namespace Heimdall.Core.ViewModel
{
    public class LandingPageViewModel : ViewModelBase
    {
        private LandingPageModel _LandingPageModel;
        public string _textInput = "What are we watching today?";

        public LandingPageViewModel()
        {
            _LandingPageModel = new LandingPageModel();
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
                OnPropertyChanged("TextInput");
            }
        }
    }
}
