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
using Map.Views.Admin;
using Map.Views.General;
using Map.Model;

namespace Map.Views
{

    public partial class LogIn : Window
    {
        private UserCreate userStorage = UserCreate.GetUser();

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_click(object sender, RoutedEventArgs e)
        {
            User user = userStorage.SearchUser(login.Text, password.Password.ToString());
            if(user== null)
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
            else
            {
                if (user.Admin)
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Вы не обладаете правами администратора и временно не имеете доступ к приложению!");
                }
            }
        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            Registration registrationForm = new Registration();
            registrationForm.Show();
            this.Close();
        }
    }
}
