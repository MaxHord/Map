using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Models.DB
{
    public class House
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int StreetId { get; set; }
        public Street street { get; set; }
        public virtual List<Flat> ListFlats { get; set; }

    }
}