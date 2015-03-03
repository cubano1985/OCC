using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Services
{
    public class ValidateService : IValidateService
    {
        private readonly IGuestDb _guestDb;

        public ValidateService(IGuestDb guestDb)
        {
            _guestDb = guestDb;
        }

        /// <summary>
        /// Method used for client side validation through Ajax call to check if given guest is already in Database.
        /// It is also used as a hardcoded check if used did provide empty name or surname.
        /// </summary>
        /// <param name="name">Guest name</param>
        /// <param name="surname">Guest surname</param>
        /// <returns>True if guest is in Database, True if name or surname is empty, false otherwise.</returns>
        public bool IsGuestInDb(string name, string surname)
        {
            var dbCheck = _guestDb.GuestList.Where(guest => guest.Name.ToLower() == name.ToLower())
                                .Any(guest => guest.Surname.ToLower() == surname.ToLower());
            
            if (name == "" || surname == "")
            {
                dbCheck = true;
            }

            return dbCheck;
        }
    }
}
