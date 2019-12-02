using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Models.DB
{
    public class City
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int CountryId { get; set; }
        public Country country { get; set; }
        public virtual List<Street> ListStreets { get; set; }

        public City() { }
    }
}