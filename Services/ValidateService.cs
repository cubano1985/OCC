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
        /// </summary>
        /// <param name="name">Guest name</param>
        /// <param name="surname">Guest surname</param>
        /// <returns>True if guest is in Database, false otherwise.</returns>
        public bool IsGuestInDb(string name, string surname)
        {
            var dbCheck = _guestDb.GuestList.Where(guest => guest.Name.ToLower() == name.ToLower())
                                .Any(guest => guest.Surname.ToLower() == surname.ToLower());
            /* I'm well aware that below check should not be present, however during the course of development
             * I have updated this soulution from MVC4 to MVC5 and through that I have encounter few problems.
             * One of them was that HTML form validation stopped preventing form from being submited. 
             * Because the problem occured just before relase I implemented this working solution to enforce 
             * form from being submited empty or partialy empty.
             */ 
            if (name == "" || surname == "")
            {
                dbCheck = true;
            }
            return dbCheck;
        }
    }
}
