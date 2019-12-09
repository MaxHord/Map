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
    /// Логика взаимодействия для AdminHouse.xaml
    /// </summary>
    public partial class AdminHouse : Window
    {
        public AdminHouse()
        {
            InitializeComponent();
            AdminHousesVM adminHousesVM = new AdminHousesVM();
            DataContext = adminHousesVM;
            adminHousesVM.ClosingRequest += (sender, e) => Close();
        }
    }
}
