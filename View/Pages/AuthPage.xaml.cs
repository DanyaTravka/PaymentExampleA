using PaymentExampleApp.Model;
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

namespace PaymentExampleApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent();
            List<Users> users = db.context.Users.ToList();
            List<string> login = new List<string>() { };
            foreach (Users item in users)
            {
                login.Add(item.Login);
            }
            UserComboBox.ItemsSource = login;
            UserComboBox.SelectedIndex = 0;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserPasswordBox.Password == db.context.Users.FirstOrDefault(x => x.Login == UserComboBox.SelectedValue.ToString()).Password)
            {
                this.NavigationService.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Вы неправильно ввели пароль");
            }
        }

 

        private void UserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.ActiveUser = UserComboBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
