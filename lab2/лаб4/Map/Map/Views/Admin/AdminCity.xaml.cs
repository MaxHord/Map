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
    /// Логика взаимодействия для AdminCity.xaml
    /// </summary>
    public partial class AdminCity : Window
    {
        public AdminCity()
        {
            InitializeComponent();
            AdminCityVM adminVM = new AdminCityVM();
            DataContext = adminVM;
            adminVM.ClosingRequest += (sender, e) => Close();
        }
    }
}
