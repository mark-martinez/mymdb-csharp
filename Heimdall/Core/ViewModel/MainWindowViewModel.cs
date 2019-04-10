using Heimdall.Core.Command;
using Heimdall.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Heimdall.Core.ViewModel;

namespace Heimdall.Core.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private List<ViewModelBase> _ViewModels;
        private ICommand _changePageCommand;

        public MainWindowViewModel()
        {
            ListViewModels.Add(new LandingPageViewModel());
            ListViewModels.Add(new ResultsViewModel());

            CurrentViewModel = _ViewModels[0];  //landing page
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                    _currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
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

        public void SwitchViewModel(ViewModelBase type)
        {
            if (!_ViewModels.Contains(type))
                _ViewModels.Add(type);

            CurrentViewModel = _ViewModels.FirstOrDefault(vm => vm == type);
        }
        
        public ICommand ChangePageCommand
        {
            get
            {
                return _changePageCommand ?? (_changePageCommand = new RelayCommand(p => SwitchViewModel(ListViewModels[1])));
                /*
                return _changePageCommand ?? (_changePageCommand = new ActionCommand(() =>
                {
                    SwitchViewModel(ListViewModels[1]);     //or new ListViewModel()
                    //need to pass actioncommand object parameter into Resultsviewmodel
                    //how to get the parameter passed into ActionCommand here????
                }
                ));
                */
            }
        }
    }
}
