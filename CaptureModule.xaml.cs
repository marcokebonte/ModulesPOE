using System;
using System.Collections;
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
    /// Interaction logic for CaptureModule.xaml
    /// </summary>
    public partial class CaptureModule : Window
    {
        // Define properties for module information
        public DatePicker MSemStartDate { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int NumberofCredits { get; set; }
        public int ClassHours { get; set; }
        public int SemWeeks { get; set; }

        public CaptureModule()
        {
            InitializeComponent();
        }

        public CaptureModule(DatePicker semStartDate, string moduleCode, string moduleName, int numberofCredits, int classHours, int semWeeks) : this()
        {
            // Initialize module information using properties
            MSemStartDate = semStartDate;
            ModuleCode = moduleCode;
            ModuleName = moduleName;
            NumberofCredits = numberofCredits;
            ClassHours = classHours;
            SemWeeks = semWeeks;
        }

        private void CapHoursBTN_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a new CaptureModule window
            CaptureModule capMod = new CaptureModule();
            capMod.Show();
        }

        private void DisplayModules_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic to display modules
            // You can add code here to populate and show a list of modules
        }

        private void HomeMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a new MainWindow
            MainWindow main = new MainWindow();
            main.Show();
            Close(); // Close the current window
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get a list of modules and set it as the data source for dataGridMods
            List<CaptureModule> modules = GetModules();
            dataGridMods.ItemsSource = modules;
        }

        // A method to create a list of modules
        public List<CaptureModule> GetModules()
        {
            List<CaptureModule> modules = new List<CaptureModule>();

            // Add the current module to the list
            modules.Add(new CaptureModule(SemStartDate, ModuleCode, ModuleName, NumberofCredits, ClassHours, SemWeeks));

            return modules;
        }
    }

}


