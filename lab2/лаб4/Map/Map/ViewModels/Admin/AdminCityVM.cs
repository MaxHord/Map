using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Models;
using Map.Models.DB;
using Map.Models.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using Map.Views.Admin;

namespace Map.ViewModels.Admin
{
    public class AdminCityVM : INotifyPropertyChanged
    {

        private Country _selectedCountry;
        private ObservableCollection<Country> _countries;

        private string _addCityName;
        private City _selectedCity;
        private ObservableCollection<City> _cities;

        private string _editCityName;

        private RelayCommand _selectCityCommand;
        private RelayCommand _selectCountryCommand;
        private RelayCommand _addCityCommand;
        private RelayCommand _editCityCommand;
        private RelayCommand _deleteCityCommand;
        private RelayCommand _closePageCommand;

        public event EventHandler ClosingRequest;

        public RelayCommand ClosePageCommand
        {
            get
            {
                return _closePageCommand ?? (_closePageCommand = new RelayCommand(obj =>
                {
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged("Cities");
            }
        }

        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                OnPropertyChanged("Countries");
            }
        }

        public string AddCityName
        {
            get { return _addCityName; }
            set
            {
                _addCityName = value;
                OnPropertyChanged("AddCityName");
            }
        }

        public string EditCityName
        {
            get { return _editCityName; }
            set
            {
                _editCityName = value;
                OnPropertyChanged("EditCityName");
            }
        }

        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }

        }

        public City SelectedCity
        {
            get {return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public RelayCommand AddCityCommand
        {
            get
            {
                return _addCityCommand ??
                    (_addCityCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var cityRepository = new CityRepository(context);
                            var countryRepository = new CountryRepository(context);
                            context.Countries.Attach(SelectedCountry);
                            City city = new City
                            {
                                Name = AddCityName,
                                country = SelectedCountry
                            };
                            cityRepository.Add(city);
                            countryRepository.Edit(SelectedCountry);
                            context.SaveChanges();
                            Cities = new ObservableCollection<City>(SelectedCountry.ListCities);
                        }
                    }));
            }
        }
        public RelayCommand SelectCityCommand
        {
            get
            {
                return _selectCityCommand ??
                    (_selectCityCommand = new RelayCommand(obj =>
                    {
                        EditCityName = SelectedCity?.Name;
                    }));
            }
        }

        public RelayCommand SelectCountryCommand
        {
            get
            {
                return _selectCountryCommand ??
                    (_selectCountryCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var countryRepository = new CountryRepository(context);
                            context.Countries.Attach(SelectedCountry);
                            countryRepository.Edit(SelectedCountry);
                            context.SaveChanges();
                            Cities = new ObservableCollection<City>(SelectedCountry.ListCities);
                        }
                    }));
            }
        }


        public RelayCommand EditCityCommand
        {
            get
            {
                return _editCityCommand ??
                    (_editCityCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var cityRepository = new CityRepository(context);
                            SelectedCity.Name = EditCityName;
                            cityRepository.Edit(SelectedCity);
                            context.SaveChanges();
                            Cities = new ObservableCollection<City>(SelectedCountry.ListCities);
                            SelectedCity = SelectedCity;
                        }
                    }));
            }
        }
        public RelayCommand DeleteCityCommand
        {
            get
            {
                return _deleteCityCommand ??
                    (_deleteCityCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var cityRepository = new CityRepository(context);
                            var countryRepository = new CountryRepository(context);
                            context.Countries.Attach(SelectedCountry);
                            cityRepository.Delete(SelectedCity);
                            countryRepository.Edit(SelectedCountry);
                            context.SaveChanges();
                            Cities = new ObservableCollection<City>(SelectedCountry.ListCities);
                        }
                    }));
            }
        }

        public Country Country { get; private set; }


        public AdminCityVM()
        {
            using (MainContext context = new MainContext())
            {
                var countryRepository = new CountryRepository(context);
                Countries = new ObservableCollection<Country>(countryRepository.List());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
