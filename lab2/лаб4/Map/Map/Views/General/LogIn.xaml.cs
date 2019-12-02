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
using Map.Models;
using Map.ViewModels.General;

namespace Map.Views
{

    public partial class LogIn : Window
    {

        public LogIn()
        {
            InitializeComponent();
            LogInViewModel logInViewModel = new LogInViewModel();
            DataContext = logInViewModel;
            logInViewModel.ClosingRequest += (sender, e) => Close();
        }

       
    }
}
