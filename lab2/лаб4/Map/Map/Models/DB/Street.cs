using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Models.DB
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<House> ListHouses { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public Street() { }

    }
}