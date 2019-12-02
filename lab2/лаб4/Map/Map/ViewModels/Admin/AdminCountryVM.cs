using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Models.DB;
using System.ComponentModel.DataAnnotations;
using Map.Models.Repositories;
using System.Collections.ObjectModel;
using Map.Models;
using System.ComponentModel;
using Map.Views.Admin;
using System.Runtime.CompilerServices;

namespace Map.ViewModels.Admin
{
   public class AdminCountryVM : INotifyPropertyChanged
    {
        private string _addCountryName;

        private Country _selectedCountry;
        private ObservableCollection<Country> _countries;
        private string _editCountryName;

        private RelayCommand _selectCountryCommand;
        private RelayCommand _addCountryCommand;
        private RelayCommand _editCountryCommand;
        private RelayCommand _deleteCountryCommand;
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

        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                OnPropertyChanged("Countries");
            }
        }

        public string AddCountryName
        {
            get { return _addCountryName; }
            set
            {
                _addCountryName = value;
                OnPropertyChanged("AddCountryName");
            }
        }
        public string EditCountryName
        {
            get { return _editCountryName; }
            set
            {
                _editCountryName = value;
                OnPropertyChanged("EditCountryName");
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

        public RelayCommand AddCountryCommand
        {
            get
            {
                return _addCountryCommand ??
                    (_addCountryCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var countryRepository = new CountryRepository(context);
                            Country country = new Country
                            {
                                Name = AddCountryName,
                                ListCities = new List<City>()
                            };
                            countryRepository.Add(country);
                            context.SaveChanges();
                            Countries = new ObservableCollection<Country>(countryRepository.List());
                        }
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
                        EditCountryName = SelectedCountry?.Name;
                    }));
            }
        }
        public RelayCommand EditCountryCommand
        {
            get
            {
                return _editCountryCommand ??
                    (_editCountryCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var countryRepositiry = new CountryRepository(context);
                            SelectedCountry.Name = EditCountryName;
                            countryRepositiry.Edit(SelectedCountry);
                            context.SaveChanges();
                            Countries = new ObservableCollection<Country>(countryRepositiry.List());
                            SelectedCountry = SelectedCountry;
                        }
                    }));
            }
        }

        public RelayCommand DeleteCountryCommand
        {
            get
            {
                return _deleteCountryCommand ??
                    (_deleteCountryCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var countryRepositiry = new CountryRepository(context);
                            countryRepositiry.Delete(SelectedCountry);
                            context.SaveChanges();
                            Countries = new ObservableCollection<Country>(countryRepositiry.List());
                        }
                    }));
            }
        }

        public AdminCountryVM()
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
