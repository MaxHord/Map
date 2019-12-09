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
    class AdminResidentVM : INotifyPropertyChanged
    {
        private string _addResidentName;
        private string _addResidentLastName;
        private string _addResidentAge;
        private Resident.GenderList? _addResidentGender;
        private string _addResidentPhone;
        private string _addResidentEmail;

        private Resident _selectedResident;
        private ObservableCollection<Resident> _residents;
        private string _editResidentName;
        private string _editResidentLastName;
        private string _editResidentAge;
        private Resident.GenderList? _editResidentGender;
        private string _editResidentPhone;
        private string _editResidentEmail;

        private RelayCommand _selectResidentCommand;
        private RelayCommand _addResidentCommand;
        private RelayCommand _editResidentCommand;
        private RelayCommand _deleteResidentCommand;
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

        public IEnumerable<Resident.GenderList> Genders
        {
            get
            {
                return Enum.GetValues(typeof(Resident.GenderList)).Cast<Resident.GenderList>();
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

        public string AddResidentName
        {
            get { return _addResidentName; }
            set
            {
                ValidateProperty(value, "AddResidentName");
                _addResidentName = value;
                OnPropertyChanged("AddResidentName");
            }
        }

        public string AddResidentLastName
        {
            get { return _addResidentLastName; }
            set
            {
                ValidateProperty(value, "AddResidentLastName");
                _addResidentLastName = value;
                OnPropertyChanged("AddResidentLastName");
            }
        }


        [RegularExpression(@"^[1-9][0-9]{0,2}$", ErrorMessage = "should be numeric")]
        public string AddResidentAge
        {
            get { return _addResidentAge; }
            set
            {
                ValidateProperty(value, "AddResidentAge");
                _addResidentAge = value;
                OnPropertyChanged("AddResidentAge");
            }
        }

        public Resident.GenderList? AddResidentGender
        {
            get { return _addResidentGender; }
            set
            {
                ValidateProperty(value, "AddResidentGender");
                _addResidentGender = value;
                OnPropertyChanged("AddResidentGender");
            }
        }

        [Phone(ErrorMessage = "should be phone number")]
        public string AddResidentPhone
        {
            get { return _addResidentPhone; }
            set
            {
                ValidateProperty(value, "AddResidentPhone");
                _addResidentPhone = value;
                OnPropertyChanged("AddResidentPhone");
            }
        }

        public string AddResidentEmail
        {
            get { return _addResidentEmail; }
            set
            {
                ValidateProperty(value, "AddResidentEmail");
                _addResidentEmail = value;
                OnPropertyChanged("AddResidentEmail");
            }
        }

        public string EditResidentName
        {
            get { return _editResidentName; }
            set
            {
                ValidateProperty(value, "EditResidentName");
                _editResidentName = value;
                OnPropertyChanged("EditResidentName");
            }
        }

        public string EditResidentLastName
        {
            get { return _editResidentLastName; }
            set
            {
                ValidateProperty(value, "EditResidentLastName");
                _editResidentLastName = value;
                OnPropertyChanged("EditResidentLastName");
            }
        }

        [RegularExpression(@"^[1-9][0-9]{0,2}$", ErrorMessage = "should be numeric")]
        public string EditResidentAge
        {
            get { return _editResidentAge; }
            set
            {
                ValidateProperty(value, "EditResidentAge");
                _editResidentAge = value;
                OnPropertyChanged("EditResidentAge");
            }
        }

        public Resident.GenderList? EditResidentGender
        {
            get { return _editResidentGender; }
            set
            {
                ValidateProperty(value, "EditResidentGender");
                _editResidentGender = value;
                OnPropertyChanged("EditResidentGender");
            }
        }

        public string EditResidentPhone
        {
            get { return _editResidentPhone; }
            set
            {
                ValidateProperty(value, "EditResidentPhone");
                _editResidentPhone = value;
                OnPropertyChanged("EditResidentPhone");
            }
        }

        public string EditResidentEmail
        {
            get { return _editResidentEmail; }
            set
            {
                ValidateProperty(value, "EditResidentEmail");
                _editResidentEmail = value;
                OnPropertyChanged("EditResidentEmail");
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

        public RelayCommand AddResidentCommand
        {
            get
            {
                return _addResidentCommand ??
                    (_addResidentCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var residentRepository = new ResidentRepository(context);
                            context.Residents.Attach(SelectedResident);
                            Resident resident = new Resident
                            {
                                Name = AddResidentName,
                                LastName = AddResidentLastName,
                                Age = int.Parse(AddResidentAge),
                                Gender = AddResidentGender,
                                Phone = AddResidentPhone,
                                Email = AddResidentEmail
                            };
                            residentRepository.Add(resident);
                            //residentRepository.List().Add(resident);
                            context.SaveChanges();
                            Residents = new ObservableCollection<Resident>(residentRepository.List());
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
                        EditResidentName = SelectedResident.Name;
                        EditResidentLastName = SelectedResident.LastName;
                        EditResidentAge = SelectedResident.Age.ToString();
                        EditResidentGender = SelectedResident.Gender;
                        EditResidentPhone = SelectedResident.Phone;
                        EditResidentEmail = SelectedResident.Email;
                    }));
            }
        }
        public RelayCommand EditResidentCommand
        {
            get
            {
                return _editResidentCommand ??
                    (_editResidentCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var residentRepository = new ResidentRepository(context);
                            SelectedResident.Name = EditResidentName;
                            SelectedResident.LastName = EditResidentLastName;
                            SelectedResident.Age = int.Parse(EditResidentAge);
                            SelectedResident.Gender = EditResidentGender;
                            SelectedResident.Phone = EditResidentPhone;
                            SelectedResident.Email = EditResidentEmail;
                            residentRepository.Edit(SelectedResident);
                            context.SaveChanges();
                            Residents = new ObservableCollection<Resident>(residentRepository.List());
                            SelectedResident = SelectedResident;
                        }
                    }));
            }
        }
        public RelayCommand DeleteResidentCommand
        {
            get
            {
                return _deleteResidentCommand ??
                    (_deleteResidentCommand = new RelayCommand(obj =>
                    {
                        using (MainContext context = new MainContext())
                        {
                            var residentRepository = new ResidentRepository(context);
                            residentRepository.List().Remove(SelectedResident);
                            context.SaveChanges();
                            Residents = new ObservableCollection<Resident>(residentRepository.List());
                        }
                    }));
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public AdminResidentVM()
        {
            using (MainContext context = new MainContext())
            {
                var residentRepository = new ResidentRepository(context);
                Residents = new ObservableCollection<Resident>(residentRepository.List());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
