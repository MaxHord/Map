using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Map.Model;

namespace Map
{
    public class Flat
    {
        public int Number { get; set; }
        public List<Reside> ListResides { get; set; }
        public int CountRooms { get; set; }
    }
}