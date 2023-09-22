using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DisplayModules.xaml
    /// </summary>
    public partial class DisplayModules : Window
    {
        public DisplayModules()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a CaptureModule instance to access the GetModules method
            CaptureModule capMod = new CaptureModule();

            // Get a list of modules using the GetModules method
            List<CaptureModule> modules = capMod.GetModules();

            // Set the list as the data source for dataGrid1
            dataGrid1.ItemsSource = modules;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create and show a new MainWindow
            MainWindow main = new MainWindow();
            main.Show();

            // Close the current window
            Close();
        }
    }


}
