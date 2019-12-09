using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map.Models.DB
{
    public class Reside
    {
        public int Id { get; set; }
        public int FlatId { get; set; }
        public Flat Flat { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        public Reside()
        {
        }
    }
}