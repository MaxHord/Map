using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map
{
    public class City
    {
        public string Name { set; get; }
        public List<Street> ListStreets { get; set; }
        private int index;

    }
}