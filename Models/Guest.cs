using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Guest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GuestGender Gender { get; set; }
        public GuestStatus Status { get; set; }

        public Guest() { }

        public Guest(string name, string Surname, GuestGender gender)
        {
            this.Name = name;
            this.Surname = Surname;
            this.Gender = gender;
        }
    }
}
