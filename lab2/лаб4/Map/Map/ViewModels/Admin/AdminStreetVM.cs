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
using System.ComponentModel.DataAnnotations;
using Map.Views.Admin;
using System.Runtime.CompilerServices;

namespace Map.ViewModels.Admin
{
    public class AdminStreetVM : INotifyPropertyChanged
    {
        private City _selectedCity;
        private ObservableCollection<City> _cities;

        private string _addStreetName;


        private Street _selectedStreet;
        private ObservableCollection<Street> _streets;
        private string _editStreetName;

        private RelayCommand _selectCityCommand;
        private RelayCommand _selectStreetCommand;
        private RelayCommand _addStreetCommand;
        private RelayCommand _editStreetCommand;
        private RelayCommand _deleteStreetCommand;
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

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public ObservableCollection<Street> Streets
        {
            get { return _streets; }
            set
            {
                _streets = value;
                OnPropertyChanged("Streets");
            }
        }

        public string AddStreetName
        {
            get { return _addStreetName; }
            set
            {
                _addStreetName = value;
                OnPropertyChanged("AddStreetName");
            }
        }

        public string EditStreetName
        {
            get { return _editStreetName; }
            set
            {
                _editStreetName = value;
                OnPropertyChanged("EditStreetName");
            }
        }

        public Street SelectedStreet
        {
            get { return _selectedStreet; }
            set
            {
                _selectedStreet = value;
                OnPropertyChanged("SelectedStreet");
            }
        }

        public RelayCommand SelectCityCommand
        {
            get
            {
                return _selectCityCommand ??
                    (_selectCityCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var cityRepository = new CityRepository(context);
                            context.Cities.Attach(SelectedCity);
                            cityRepository.Edit(SelectedCity);
                            context.SaveChanges();
                            Streets = new ObservableCollection<Street>(SelectedCity.ListStreets);
                        }
                    }));
            }
        }

        public RelayCommand AddStreetCommand
        {
            get
            {
                return _addStreetCommand ??
                    (_addStreetCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var streetRepository = new StreetRepository(context);
                            var cityRepository = new CityRepository(context);
                            context.Cities.Attach(SelectedCity);
                            Street street = new Street
                            {
                                Name = AddStreetName,
                                City = SelectedCity
                            };
                            streetRepository.Add(street);
                            cityRepository.Edit(SelectedCity);
                            context.SaveChanges();
                            Streets = new ObservableCollection<Street>(SelectedCity.ListStreets);
                        }
                    }));
            }
        }
        public RelayCommand SelectStreetCommand
        {
            get
            {
                return _selectStreetCommand ??
                    (_selectStreetCommand = new RelayCommand(obj =>
                    {
                        EditStreetName = SelectedStreet?.Name;
                    }));
            }
        }
        public RelayCommand EditStreetCommand
        {
            get
            {
                return _editStreetCommand ??
                    (_editStreetCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var streetRepository = new StreetRepository(context);
                            SelectedStreet.Name = EditStreetName;
                            streetRepository.Edit(SelectedStreet);
                            context.SaveChanges();
                            Streets = new ObservableCollection<Street>(SelectedCity.ListStreets);
                            SelectedStreet = SelectedStreet;
                        }
                    }));
            }
        }
        public RelayCommand DeleteStreetCommand
        {
            get
            {
                return _deleteStreetCommand ??
                    (_deleteStreetCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var streetRepository = new StreetRepository(context);
                            var cityRepository = new CityRepository(context);
                            context.Cities.Attach(SelectedCity);
                            streetRepository.Delete(SelectedStreet);
                            cityRepository.Edit(SelectedCity);
                            context.SaveChanges();
                            Streets = new ObservableCollection<Street>(SelectedCity.ListStreets);
                        }
                    }));
            }
        }


        public City City { get; private set; }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public AdminStreetVM()
        {
            using (MainContext context = new MainContext())
            {
                var cityRepository = new CityRepository(context);
                Cities = new ObservableCollection<City>(cityRepository.List());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
