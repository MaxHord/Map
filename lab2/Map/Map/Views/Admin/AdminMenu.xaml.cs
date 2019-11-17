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

namespace Map.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void country_click(object sender, RoutedEventArgs e)
        {
            AdminCountry adminCountry = new AdminCountry();
            adminCountry.Show();
            Close();
        }

        private void city_click(object sender, RoutedEventArgs e)
        {
            AdminCity adminCity = new AdminCity();
            adminCity.Show();
            Close();
        }

        private void street_click(object sender, RoutedEventArgs e)
        {
            AdminStreet adminStreet = new AdminStreet();
            adminStreet.Show();
            Close();
        }

        private void house_click(object sender, RoutedEventArgs e)
        {
            AdminHouse adminHouse = new AdminHouse();
            adminHouse.Show();
            Close();
        }

        private void flat_click(object sender, RoutedEventArgs e)
        {
            AdminFlat adminFlat = new AdminFlat();
            adminFlat.Show();
            Close();
        }

        private void resident_click(object sender, RoutedEventArgs e)
        {
            AdminResident adminResident = new AdminResident();
            adminResident.Show();
            Close();
        }

        private void reside_click(object sender, RoutedEventArgs e)
        {
            AdminFlatToResident adminFlatToResident = new AdminFlatToResident();
            adminFlatToResident.Show();
            Close();
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Close();
        }
    }
}
