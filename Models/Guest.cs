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

    }
}
