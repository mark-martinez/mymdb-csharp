using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Heimdall.API;
using Heimdall.Core.View;
using Heimdall.Core.ViewModel;

namespace Heimdall.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        void App_StartUp(object sender, StartupEventArgs e)
        {
            Application.Current.Resources.Add("Configuration", Configuration.Instance);
            //this.StartupUri = new Uri("Core/View/MainWindow.xaml", UriKind.RelativeOrAbsolute);
            MainWindow mw = new MainWindow();
            MainWindowViewModel vm = new MainWindowViewModel();
            mw.DataContext = vm;
            mw.Show();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }
}