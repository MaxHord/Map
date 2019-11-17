using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    public class Resident
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public enum GenderList { male, female}
        public GenderList Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Resident()
        {
        }
    }
}
