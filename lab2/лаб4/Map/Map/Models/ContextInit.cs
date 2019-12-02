using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Map.Models.Repositories;

namespace Map.Models
{
    class ContextInit : CreateDatabaseIfNotExists<MainContext>
    {

        private CountryRepository _countryRepository;
        private CityRepository _cityRepository;
        private StreetRepository _streetRepository;
        private HouseRepository _houseRepository;
        private FlatRepository _roomRepository;
        private ResideRepository _roomResidentRepository;
        private ResidentRepository _residentRepository;
        private UserRepository _userRepository;

    }
}
