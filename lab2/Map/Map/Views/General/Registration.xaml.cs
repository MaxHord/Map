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
using Map.Model;

namespace Map.Views.General
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private UserCreate userStorage = UserCreate.GetUser();

        public Registration()
        {
            InitializeComponent();
        }

        private void regitr_click(object sender, RoutedEventArgs e)
        {
            if (password.Password.ToString() == password_double.Password.ToString())
            {
                User user = userStorage.SearchUser(reg_login.Text, password.Password.ToString());
                if (user == null)
                {
                    User newUser = new User(reg_login.Text, password.Password.ToString(), false);
                    userStorage.Users.Add(newUser);
                    MessageBox.Show("Вы успешно зарегистрировались!");
                    LogIn logIn = new LogIn();
                    logIn.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует!");
                }
            }
            else
            {
                MessageBox.Show("Введины разные пароли!");
            }
        }

    }
}
