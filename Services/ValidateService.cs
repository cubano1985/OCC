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

        public bool IsGuestInDb(string name, string surname)
        {
            var dbCheck = _guestDb.GuestList.Where(guest => guest.Name.ToLower() == name.ToLower())
                                .Any(guest => guest.Surname.ToLower() == surname.ToLower());
            return dbCheck;
        }
    }
}
