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
using System.Windows;

namespace Map.ViewModels.Admin
{
    class AdminResideVM : INotifyPropertyChanged 
    {
        private string _deleteResidentLastName;
        private string _deleteFlatNumber;

        private Reside _selectedReside;
        private ObservableCollection<Reside> _reside;

        private Resident _selectedResident;
        private ObservableCollection<Resident> _residents;

        private Flat _selectedFlat;
        private ObservableCollection<Flat> _Flats;

        private RelayCommand _selectResidentCommand;
        private RelayCommand _selectFlatCommand;
        private RelayCommand _addResideCommand;
        private RelayCommand _deleteResideCommand;
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

        public string DeleteResidentLastName
        {
            get { return _deleteResidentLastName; }
            set
            {
                ValidateProperty(value, "DeleteResidentLastName");
                _deleteResidentLastName = value;
                OnPropertyChanged("DeleteResidentLastName");
            }
        }

        public string DeleteFlatNumber
        {
            get { return _deleteFlatNumber; }
            set
            {
                ValidateProperty(value, "DeleteFlatNumber");
                _deleteFlatNumber = value;
                OnPropertyChanged("DeleteFlatNumber");
            }
        }

        public ObservableCollection<Reside> Reside
        {
            get { return _reside; }
            set
            {
                _reside = value;
                OnPropertyChanged("Reside");
            }
        }

        public RelayCommand AddResideCommand
        {
            get
            {
                return _addResideCommand ??
                    (_addResideCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var resideRepository = new ResideRepository(context);
                            var residentRepository = new ResidentRepository(context);
                            var flatRepository = new FlatRepository(context);
                            Resident _resident = residentRepository.List(r => r.LastName == DeleteResidentLastName).FirstOrDefault();
                            Flat _flat = flatRepository.List(f => f.Number.ToString() == DeleteFlatNumber).FirstOrDefault();
                            if (_resident != null && _flat != null)
                            {
                                if (_flat.ListResides.Find(f=>f.Resident.Equals(_resident))==null)
                                {
                                    Reside resides = new Reside
                                    {
                                        Flat = _flat,
                                        Resident = _resident
                                    };
                                    resideRepository.Add(resides);
                                    flatRepository.Edit(_flat);
                                    residentRepository.Edit(_resident);
                                    context.SaveChanges();

                                }
                                else
                                {
                                    MessageBox.Show("!!Room already contains such resident");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Такой житель не проживает в этой комнате!");
                            }
                        }
                    }));
            }
        }

        public RelayCommand SelectResidentCommand
        {
            get
            {
                return _selectResidentCommand ??
                    (_selectResidentCommand = new RelayCommand(obj =>
                    {
                    }));
            }
        }

        public RelayCommand DeleteResideCommand
        {
            get
            {
                return _deleteResideCommand ??
                    (_deleteResideCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var resideRepository = new ResideRepository(context);
                            var residentRepository = new ResidentRepository(context);
                            var flatRepository = new FlatRepository(context);
                            Resident resident = residentRepository.List(r => r.LastName == DeleteResidentLastName).FirstOrDefault();
                            Flat flat = flatRepository.List(f => f.Number.ToString() == DeleteFlatNumber).FirstOrDefault();
                            if(resident !=null && flat != null)
                            {
                                Reside resides = flat.ListResides.Find(f => f.Resident.Equals(resident));
                                if(resides!= null)
                                {
                                    resideRepository.Delete(resides);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    MessageBox.Show("Такой житель не проживает в этой комнате!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Такой житель не проживает в этой комнате!");
                            }
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

        public ObservableCollection<Resident> Residents
        {
            get { return _residents; }
            set
            {
                _residents = value;
                OnPropertyChanged("Residents");
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

        public Resident SelectedResident
        {
            get { return _selectedResident; }
            set
            {
                ValidateProperty(value, "SelectedResident");
                _selectedResident = value;
                OnPropertyChanged("SelectedResident");
            }
        }

        public Reside SelectedReside
        {
            get { return _selectedReside; }
            set
            {
                ValidateProperty(value, "SelectedReside");
                _selectedReside = value;
                OnPropertyChanged("SelectedReside");
            }
        }


        public AdminResideVM()
        {
            using (MainContext context = new MainContext())
            {
                var flatRepository = new FlatRepository(context);
                Flats = new ObservableCollection<Flat>(flatRepository.List());

                var residentRepository = new ResidentRepository(context);
                Residents = new ObservableCollection<Resident>(residentRepository.List());
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
