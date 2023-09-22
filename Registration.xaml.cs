using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        // Use a List<string> instead of ArrayList for better type safety
        public List<string> userInfo = new List<string>();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a new Login window
            Login login = new Login();
            login.Show();

            // Close the current Registration window
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            // Clear the input fields and error message using LINQ
            foreach (var textBox in new[] { textBoxFirstName, textBoxLastName, textBoxEmail, textBoxAddress })
            {
                textBox.Text = "";
            }

            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
            errormessage.Text = "";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // Close the current Registration window
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Validate and process the registration data

            // Use LINQ to check for duplicate emails in userInfo
            string email = textBoxEmail.Text;
            bool emailExists = userInfo.Any(u => u == email);

            if (emailExists)
            {
                errormessage.Text = "This email is already registered.";
                textBoxEmail.Focus();
            }
            else if (string.IsNullOrEmpty(email))
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string password = passwordBox1.Password;

                if (string.IsNullOrEmpty(password))
                {
                    errormessage.Text = "Enter a password.";
                    passwordBox1.Focus();
                }
                else if (string.IsNullOrEmpty(passwordBoxConfirm.Password))
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Confirm password must be the same as the password.";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    // Registration successful, add user info to the list
                    errormessage.Text = "";
                    string address = textBoxAddress.Text;

                    userInfo.Add(firstname);
                    userInfo.Add(lastname);
                    userInfo.Add(email);
                    userInfo.Add(password);
                    userInfo.Add(address);
                    errormessage.Text = "You have registered successfully.";

                    // Create and show a new Login window
                    Login login = new Login();
                    login.Show();
                }
            }
        }
    }
}
    

