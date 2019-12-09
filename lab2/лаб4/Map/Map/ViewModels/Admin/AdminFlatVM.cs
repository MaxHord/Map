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
    class AdminFlatVM : INotifyPropertyChanged
    {
        private string _addFlatNumber;
        private string _addFlatCountRooms;

        private House _selectedHouse;
        private ObservableCollection<House> _houses;

        private Flat _selectedFlat;
        private ObservableCollection<Flat> _Flats;
        private string _editFlatNumber;
        private string _editFlatCountRooms;

        private RelayCommand _selectHouseCommand;
        private RelayCommand _selectFlatCommand;
        private RelayCommand _addFlatCommand;
        private RelayCommand _editFlatCommand;
        private RelayCommand _deleteFlatCommand;
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

        public RelayCommand SelectHouseCommand
        {
            get
            {
                return _selectHouseCommand ??
                    (_selectHouseCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var houseRepository = new HouseRepository(context);
                            context.Houses.Attach(SelectedHouse);
                            houseRepository.Edit(SelectedHouse);
                            context.SaveChanges();
                            Flats = new ObservableCollection<Flat>(SelectedHouse.ListFlats);
                        }
                    }));
            }
        }

        public ObservableCollection<Flat> Flats
        {
            get { return _Flats; }
            set
            {
                _Flats = value;
                OnPropertyChanged("Flats");
            }
        }

        [RegularExpression(@"^[1-9][0-9]{0,2}$", ErrorMessage = "should be numeric")]
        public string AddFlatNumber
        {
            get { return _addFlatNumber; }
            set
            {
                ValidateProperty(value, "AddFlatNumber");
                _addFlatNumber = value;
                OnPropertyChanged("AddFlatNumber");
            }
        }

        [RegularExpression(@"^[1-9][0-9]{0,3}$", ErrorMessage = "should be numeric")]
        public string AddFlatCountRooms
        {
            get { return _addFlatCountRooms; }
            set
            {
                ValidateProperty(value, "AddFlatCountRooms");
                _addFlatCountRooms = value;
                OnPropertyChanged("AddFlatCountRooms");
            }
        }

        public string EditFlatNumber
        {
            get { return _editFlatNumber; }
            set
            {
                ValidateProperty(value, "EditFlatNumber");
                _editFlatNumber = value;
                OnPropertyChanged("EditFlatNumber");
            }
        }
        
        public string EditFlatCountRooms
        {
            get { return _editFlatCountRooms; }
            set
            {
                ValidateProperty(value, "EditFlatCountRooms");
                _editFlatCountRooms = value;
                OnPropertyChanged("EditFlatCountRooms");
            }
        }
 
        public Flat SelectedFlat
        {
            get { return _selectedFlat; }
            set
            {
                ValidateProperty(value, "SelectedFlat");
                _selectedFlat = value;
                OnPropertyChanged("SelectedFlat");
            }
        }

        public RelayCommand AddFlatCommand
        {
            get
            {
                return _addFlatCommand ??
                    (_addFlatCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var FlatRepository = new FlatRepository(context);
                            var houseRepository = new HouseRepository(context);
                            context.Houses.Attach(SelectedHouse);
                            Flat Flat = new Flat
                            {
                                Number = int.Parse(AddFlatNumber),
                                CountRooms = int.Parse(AddFlatCountRooms),
                                house = SelectedHouse
                            };
                            FlatRepository.Add(Flat);
                            houseRepository.Edit(SelectedHouse);
                            context.SaveChanges();
                            Flats = new ObservableCollection<Flat>(SelectedHouse.ListFlats);
                        }
                    }));
            }
        }
        public RelayCommand SelectFlatCommand
        {
            get
            {
                return _selectFlatCommand ??
                    (_selectFlatCommand = new RelayCommand(obj =>
                    {
                        EditFlatNumber = Convert.ToString(SelectedFlat.Number);
                        EditFlatCountRooms = Convert.ToString(SelectedFlat.CountRooms);
                    }));
            }
        }
        public RelayCommand EditFlatCommand
        {
            get
            {
                return _editFlatCommand ??
                    (_editFlatCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var FlatRep = new FlatRepository(context);
                            SelectedFlat.Number = int.Parse(EditFlatNumber);
                            SelectedFlat.CountRooms = int.Parse(EditFlatCountRooms);
                            FlatRep.Edit(SelectedFlat);
                            context.SaveChanges();
                            Flats = new ObservableCollection<Flat>(House.ListFlats);
                            SelectedFlat = SelectedFlat;
                        }
                    }));
            }
        }
        public RelayCommand DeleteFlatCommand
        {
            get
            {
                return _deleteFlatCommand ??
                    (_deleteFlatCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var FlatRep = new FlatRepository(context);
                            var houseRep = new HouseRepository(context);
                            context.Houses.Attach(House);
                            FlatRep.Delete(SelectedFlat);
                            houseRep.Edit(House);
                            context.SaveChanges();
                            Flats = new ObservableCollection<Flat>(House.ListFlats);
                        }
                    }));
            }
        }

        public House House { get; private set; }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public AdminFlatVM()
        {
            using (MainContext context = new MainContext())
            {
                var houseRepository = new HouseRepository(context);
                Houses = new ObservableCollection<House>(houseRepository.List());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
