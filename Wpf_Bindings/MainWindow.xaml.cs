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

namespace Wpf_Bindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User CurrentUser { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            CurrentUser = new User()
            {
                Email = "cosmos@ukr.net",
                Age = 33,
                AuthData = new AuthData()
                {
                    Login = "blablalogin",
                    Password = "Qwerty"
                }
            };

            this.DataContext = CurrentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CurrentUser.ToString());
        }
    }

    // Binding is possible for public properties in classes
    public class User
    {
        public string name;
        public string Email { get; set; }
        public int Age { get; set; }
        public AuthData AuthData { get; set; }
        public override string ToString()
        {
            return $"User: {Email}, {Age}, {AuthData.Login}, " +
                   $"{AuthData.Password.First()}{new string('#', AuthData.Password.Length - 2)}{AuthData.Password.Last()}";
        }
    }
    public class AuthData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
