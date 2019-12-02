using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Map.Models;
using Map.Models.Repositories;

namespace Map.ViewModels.General
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        private RelayCommand _registerCommand;
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

        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ??
                    (_registerCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var userRepository = new UserRepository(context);
                            Models.DB.User user = userRepository.List(u => (u.Login == Username && u.Password == Password)).FirstOrDefault();
                            if (user == null)
                            {
                                Models.DB.User newUser = new Models.DB.User
                                {
                                    Login = Username,
                                    Password = Password,
                                    Admin = false
                                };
                                userRepository.Add(newUser);
                                context.SaveChanges();
                                ClosingRequest?.Invoke(this, EventArgs.Empty);
                            }
                            else
                            {
                                MessageBox.Show("Пользователь с таким именем уже существует!");
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
