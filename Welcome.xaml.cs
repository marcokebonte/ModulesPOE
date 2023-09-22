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
using System.Windows.Shapes;

namespace ModulesPOE
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a new Login window
            Login login = new Login();
            login.Show();

            // Close the current Welcome window
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create and show a new Registration window
            Registration register = new Registration();
            register.Show();

            // Close the current Welcome window
            Close();
        }
    }
}

