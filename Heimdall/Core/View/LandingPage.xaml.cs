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

namespace Heimdall.Core.View
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : UserControl
    {
        public LandingPage()
        {
            InitializeComponent();
            //this.TextMain.Focus();
            Keyboard.Focus(this.TextMain);
            this.KeyDown += (s, e) =>
            {
                this.TextMain.Focus();
            };
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TextMain.Text = string.Empty;
            this.TextMain.GotFocus -= TextBox_GotFocus;
        }
    }
}
