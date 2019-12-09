using Map.ViewModels.Admin;
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

namespace Map.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdmminCountry.xaml
    /// </summary>
    public partial class AdminCountry : Window
    {

        public AdminCountry()
        {
            InitializeComponent();
            AdminCountryVM adminCountryVM = new AdminCountryVM();
            DataContext = adminCountryVM;
            adminCountryVM.ClosingRequest += (sender, e) => Close();
        }

    }
}
