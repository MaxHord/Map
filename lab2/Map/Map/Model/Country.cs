using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map
{
    public class Country
    {
        public string Name { get; set; }
        public List<City> ListCities { get; set; }

        public Country()
        {
        }
    }
}