using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Map.Models.Repositories;
using Map.Views.General;
using Map.Views.Admin;
using System.Windows;
using System.Windows.Controls;
using Map.Models;

namespace Map.ViewModels.General
{
    class LogInViewModel : INotifyPropertyChanged
    {

        private string _username;
        private string _password;

        private RelayCommand _openRegistrationPageCommand;
        private RelayCommand _loginCommand;
        private RelayCommand _passwordChangedCommand;

        public event EventHandler ClosingRequest;

        [Required(ErrorMessage = "Поля не могут быть пустыми")]
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public RelayCommand OpenRegistrationPageCommand
        {
            get
            {
                return _openRegistrationPageCommand ??
                    (_openRegistrationPageCommand = new RelayCommand(obj =>
                    {
                        Registration registration = new Registration();
                        registration.Show();
                    }));
            }
        }
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                    (_loginCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var userRepository = new UserRepository(context);
                            Models.DB.User user = userRepository.List(u => (u.Login == Username && u.Password == Password)).FirstOrDefault();
                            if (user == null)
                            {
                                MessageBox.Show("Проверьте правильность введеных данных!");
                            }
                            else
                            {
                                Models.AppContext.CurrentUser = user;
                                if (user.Admin)
                                {
                                    AdminMenu adminPage = new AdminMenu();
                                    adminPage.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Функционал для пользователя еще не реализован!");
                                }
                                ClosingRequest?.Invoke(this, EventArgs.Empty);
                            }
                        }
                    }));
            }
        }
        public RelayCommand PasswordChangedCommand
        {
            get
            {
                return _passwordChangedCommand ??
                    (_passwordChangedCommand = new RelayCommand(obj =>
                    {
                        PasswordBox passwordBox = obj as PasswordBox;
                        Password = passwordBox.Password;
                    }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
