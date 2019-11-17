using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    public class Repositories
    {
        public List<Country> Countries { get; private set; } = new List<Country>();
        public List<City> Cities { get; private set; } = new List<City>();
        public List<Street> Streets { get; private set; } = new List<Street>();
        public List<House> Houses { get; private set; } = new List<House>();
        public List<Flat> Flats { get; private set; } = new List<Flat>();
        public List<Resident> Residents { get; private set; } = new List<Resident>();
        private static Repositories repository;

        public static Repositories GetData()
        {
            if (repository == null)
            {
                repository = new Repositories();
            }
            return repository;
        }

        private Repositories()
        {
            for (int i = 0; i < 10; i++)
            {
                AddCountry(Countries, 15);
            }
        }

        private void AddCountry(List<Country> countries, int citiesCount)
        {
            int no = countries.Count + 1;
            Country country = new Country
            {
                Name = "Country #" + no,
                ListCities = new List<City>()
            };

            for (int i = 0; i < citiesCount; i++)
            {
                AddCity(country.ListCities, 20);
            }
            countries.Add(country);
        }

        private void AddCity(List<City> cities, int streetsCount)
        {
            int no = cities.Count + 1;
            City city = new City
            {
                Name = "City #" + no,
                ListStreets = new List<Street>()
            };
            for (int i = 0; i < streetsCount; i++)
            {
                AddStreet(city.ListStreets, 10);
            }
            cities.Add(city);
            Cities.Add(city);
        }

        private void AddStreet(List<Street> streets, int housesCount)
        {
            int no = streets.Count + 1;
            Street street = new Street
            {
                Name = "Street #" + no,
                ListHouses = new List<House>()
            };
            for (int i = 0; i < housesCount; i++)
            {
                AddHouse(street.ListHouses, 5);
            }
            streets.Add(street);
            Streets.Add(street);
        }

        private void AddHouse(List<House> houses, int roomsCount)
        {
            int no = houses.Count + 1;
            House house = new House
            {
                Number = no,
                ListFlats = new List<Flat>()
            };
            for (int i = 0; i < roomsCount; i++)
            {
                AddFlat(house.ListFlats, 3);
            }
            houses.Add(house);
            Houses.Add(house);
        }

        private void AddFlat(List<Flat> flats, int residentsCount)
        {
            int no = flats.Count + 1;
            Flat flat = new Flat
            {
                Number = no,
                ListResides = new List<Reside>()
            };
            for (int i = 0; i < residentsCount; i++)
            {
                AddReside(flat.ListResides, flat);
            }
            flats.Add(flat);
            flats.Add(flat);
        }

        private void AddReside(List<Reside> listResides, Flat flat)
        {
            int no = listResides.Count + 1;
            Resident resident = new Resident
            {
                Name = "Resident #" + no,
                LastName = "Resident #" + no,
                Age = 30 + no % 10,
                Gender = Resident.GenderList.male,
                Phone = "Phone #" + no,
                Email= "Email #"+no
            };
            Residents.Add(resident);

            Reside reside = new Reside
            {
                Resident = resident,
                Flat = flat
            };
            listResides.Add(reside);
        }
    }
}
