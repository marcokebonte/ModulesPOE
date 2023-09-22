using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Registration registration;
        private Welcome welcome;
        private List<User> users;

        public Login()
        {
            InitializeComponent();

            registration = new Registration();
            welcome = new Welcome();
            users = new List<User>();

            // Add some sample users for testing
            users.Add(new User { Email = "user1@example.com", PasswordHash = HashPassword("password1") });
            users.Add(new User { Email = "user2@example.com", PasswordHash = HashPassword("password2") });
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = passwordBox1.Password;

            if (string.IsNullOrEmpty(email))
            {
                ShowErrorMessage("Enter an email address.");
                textBoxEmail.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                ShowErrorMessage("Please enter a valid email address.");
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
                return;
            }

            User user = users.FirstOrDefault(u => u.Email == email && VerifyPassword(password, u.PasswordHash));

            if (user != null)
            {
                ShowSuccessMessage("You have successfully logged in!");
                MainWindow main = new MainWindow();
                main.DisplayCurrentUserLabel.Content = "Welcome " + email;
                main.Show();
                Close();
            }
            else
            {
                ShowErrorMessage("Sorry! Please enter valid email and password.");
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        // Expression to validate email addresses
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        // Password hashing function
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Verify the entered password against the stored password hash
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            string enteredPasswordHash = HashPassword(enteredPassword);
            return enteredPasswordHash == storedPasswordHash;
        }

        // Display an error message to the user
        private void ShowErrorMessage(string message)
        {
            errormessage.Text = message;
        }

        // Display a success message to the user
        private void ShowSuccessMessage(string message)
        {
            errormessage.Text = message;
        }

        // User class to represent user data
        private class User
        {
            public string Email { get; set; }
            public string PasswordHash { get; set; }
        }
    }
}
    

