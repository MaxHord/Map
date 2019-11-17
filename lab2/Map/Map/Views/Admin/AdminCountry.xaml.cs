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

namespace Map.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdmminCountry.xaml
    /// </summary>
    public partial class AdminCountry : Window
    {
        private Repositories repository = Repositories.GetData();

        public AdminCountry()
        {
            InitializeComponent();
            this.DataContext = repository;
        }

        private void AddCountry_click(object sender, RoutedEventArgs e)
        {
            Country country = new Country
            {
                Name = AddName.Text,
                ListCities = new List<City>()
            };
            repository.Countries.Add(country);
            RefreshBox.RefreshComboBox(ListCountries_box);
            MessageBox.Show("ok");
        }

        private void DeleteCountry_click(object sender, RoutedEventArgs e)
        {
            Country country = (Country)ListCountries_box.SelectedItem;
            if (country != null)
            {
                repository.Countries.Remove(country);
                RefreshBox.RefreshComboBox(ListCountries_box);
            }
            else
            {
                MessageBox.Show("Страна не найдена!");
            }
        }

        private void ChangeCountry_click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListCountries_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Country country = (Country)ListCountries_box.SelectedItem;
            //editCountryName.Text = country?.Name;
            //editCapital.ItemsSource = country?.Cities;
            //editCapital.SelectedItem = country?.Capital;
        }
    }
}
