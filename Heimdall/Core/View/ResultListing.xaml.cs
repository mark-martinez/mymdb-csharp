using MyMDB.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMDB.Core.View
{
    /// <summary>
    /// Interaction logic for ResultListing.xaml
    /// </summary>
    public partial class ResultListing : UserControl
    {
        public ResultListing(Media media)
        {
            InitializeComponent();
            this.DataContext = media;
        }
    }
}
