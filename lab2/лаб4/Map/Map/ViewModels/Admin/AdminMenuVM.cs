using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Map.Views.General;
using Map.Views;
using Map.Views.Admin;

namespace Map.ViewModels.Admin
{
    class AdminMenuVM : INotifyPropertyChanged
    {

        private RelayCommand _openCountryCommand;
        private RelayCommand _openCityCommand;
        private RelayCommand _openFlatCommand;
        private RelayCommand _openStreetCommand;
        private RelayCommand _openHouseCommand;
        private RelayCommand _openResidentCommand;
        private RelayCommand _openResideCommand;
        private RelayCommand _closePageCommand;

        public event EventHandler ClosingRequest;

        public RelayCommand OpenCountryCommand
        {
            get
            {
                return _openCountryCommand ?? (_openCountryCommand = new RelayCommand(obj =>
                {
                    AdminCountry adminCountry = new AdminCountry();
                    adminCountry.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand OpenCityCommand
        {
            get
            {
                return _openCityCommand ?? (_openCityCommand = new RelayCommand(obj =>
                {
                    AdminCity adminCity = new AdminCity();
                    adminCity.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand OpenStreetCommand
        {
            get
            {
                return _openStreetCommand ?? (_openStreetCommand = new RelayCommand(obj =>
                {
                    AdminStreet adminStreet = new AdminStreet();
                    adminStreet.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand OpenHouseCommand
        {
            get
            {
                return _openHouseCommand ?? (_openHouseCommand = new RelayCommand(obj =>
                {
                    AdminHouse adminHouse = new AdminHouse();
                    adminHouse.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand OpenFlatCommand
        {
            get
            {
                return _openFlatCommand ?? (_openFlatCommand = new RelayCommand(obj =>
                {
                    AdminFlat adminFlat = new AdminFlat();
                    adminFlat.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand OpenResidentCommand
        {
            get
            {
                return _openResidentCommand ?? (_openResidentCommand = new RelayCommand(obj =>
                {
                    AdminResident adminResident = new AdminResident();
                    adminResident.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand OpenResideCommand
        {
            get
            {
                return _openResideCommand ?? (_openResideCommand = new RelayCommand(obj =>
                {
                    AdminFlatToResident adminReside = new AdminFlatToResident();
                    adminReside.Show();
                    ClosingRequest?.Invoke(this, EventArgs.Empty);
                }));
            }
        }

        public RelayCommand ClosePageCommand
        {
            get
            {
                return _closePageCommand ?? (_closePageCommand = new RelayCommand(obj =>
                  {
                      LogIn logIn = new LogIn();
                      logIn.Show();
                      ClosingRequest?.Invoke(this, EventArgs.Empty);
                  }));
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
