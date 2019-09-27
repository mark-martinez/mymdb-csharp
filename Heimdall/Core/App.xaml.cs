using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MyMDB.Core.API;
using MyMDB.Core.DB;
using MyMDB.Core.View;
using MyMDB.Core.ViewModel;

namespace MyMDB.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        void App_StartUp(object sender, StartupEventArgs e)
        {
            MainWindow mw = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
            mw.Show();
        }
    }
}