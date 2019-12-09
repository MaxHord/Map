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
    class AdminHousesVM : INotifyPropertyChanged
    {

        private Street _selectedStreet;
        private ObservableCollection<Street> _streets;

        private string _addHouseAddress;

        private House _selectedHouse;
        private ObservableCollection<House> _houses;
        private string _editHouseAddress;

        private RelayCommand _selectStreetCommand;
        private RelayCommand _selectHouseCommand;
        private RelayCommand _addHouseCommand;
        private RelayCommand _editHouseCommand;
        private RelayCommand _deleteHouseCommand;
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

        public ObservableCollection<Street> Streets
        {
            get { return _streets; }
            set
            {
                _streets = value;
                OnPropertyChanged("Streets");
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

        public RelayCommand SelectStreetCommand
        {
            get
            {
                return _selectStreetCommand ??
                    (_selectStreetCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var streetRepository = new StreetRepository(context);
                            context.Streets.Attach(SelectedStreet);
                            streetRepository.Edit(SelectedStreet);
                            context.SaveChanges();
                            Houses = new ObservableCollection<House>(SelectedStreet.ListHouses);
                        }
                    }));
            }
        }

        public ObservableCollection<House> Houses
        {
            get { return _houses; }
            set
            {
                ValidateProperty(value, "Houses");
                _houses = value;
                OnPropertyChanged("Houses");
            }
        }


        public string AddHouseAddress
        {
            get { return _addHouseAddress; }
            set
            {
                ValidateProperty(value, "AddHouseAddress");
                _addHouseAddress = value;
                OnPropertyChanged("AddHouseAddress");
            }
        }

        public string EditHouseAddress
        {
            get { return _editHouseAddress; }
            set
            {
                ValidateProperty(value, "EditHouseAddress");
                _editHouseAddress = value;
                OnPropertyChanged("EditHouseAddress");
            }
        }

        public House SelectedHouse
        {
            get { return _selectedHouse; }
            set
            {
                ValidateProperty(value, "SelectedHouse");
                _selectedHouse = value;
                OnPropertyChanged("SelectedHouse");
            }
        }

        public RelayCommand AddHouseCommand
        {
            get
            {
                return _addHouseCommand ??
                    (_addHouseCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var houseRepository = new HouseRepository(context);
                            var streetRepository = new StreetRepository(context);
                            context.Streets.Attach(SelectedStreet);
                            House house = new House
                            {
                                Number = AddHouseAddress,
                                Street = SelectedStreet
                            };
                            houseRepository.Add(house);
                            streetRepository.Edit(SelectedStreet);
                            context.SaveChanges();
                            Houses = new ObservableCollection<House>(SelectedStreet.ListHouses);
                        }
                    }));
            }
        }
        public RelayCommand SelectHouseCommand
        {
            get
            {
                return _selectHouseCommand ??
                    (_selectHouseCommand = new RelayCommand(obj =>
                    {
                        EditHouseAddress = SelectedHouse?.Number;
                    }));
            }
        }
        public RelayCommand EditHouseCommand
        {
            get
            {
                return _editHouseCommand ??
                    (_editHouseCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var houseRepository = new HouseRepository(context);
                            SelectedHouse.Number = EditHouseAddress;
                            houseRepository.Edit(SelectedHouse);
                            context.SaveChanges();
                            Houses = new ObservableCollection<House>(SelectedStreet.ListHouses);
                            SelectedHouse = SelectedHouse;
                        }
                    }));
            }
        }
        public RelayCommand DeleteHouseCommand
        {
            get
            {
                return _deleteHouseCommand ??
                    (_deleteHouseCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var houseRepository = new HouseRepository(context);
                            var streetRepository = new StreetRepository(context);
                            context.Streets.Attach(SelectedStreet);
                            houseRepository.Delete(SelectedHouse);
                            streetRepository.Edit(SelectedStreet);
                            context.SaveChanges();
                            Houses = new ObservableCollection<House>(SelectedStreet.ListHouses);
                        }
                    }));
            }
        }


        public Street Street { get; private set; }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public AdminHousesVM()
        {
            using (MainContext context = new MainContext())
            {
                var streetRepository = new StreetRepository(context);
                Streets = new ObservableCollection<Street>(streetRepository.List());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
