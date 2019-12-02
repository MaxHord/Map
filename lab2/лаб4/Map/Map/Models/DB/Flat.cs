using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Models.DB
{
    public class Flat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public virtual List<Reside> ListResides { get; set; }
        public int CountRooms { get; set; }
        public int HouseId { get; set; }
        public House house { get; set; }
    }
}