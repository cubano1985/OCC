using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Guest
    {
        //Static enumerator for Guests on the List
        private static int idOrder = 1;

        public int Id { get; set; }
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

            this.Status = GuestStatus.Invited;
            this.Id = idOrder++;
        }
    }
}
