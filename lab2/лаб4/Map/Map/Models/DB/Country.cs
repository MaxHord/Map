using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Models.DB
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<City> ListCities { get; set; }

        public Country()
        {
        }
    }
}