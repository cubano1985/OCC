using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.DataTransferObjects;
using DataBase;

namespace Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestDb _guestDb;

        public GuestService(IGuestDb guestDb)
        {
            _guestDb = guestDb;
        }

        public List<Guest> GetGuestList()
        {
            var response = _guestDb.GuestList;
            return response;
        }

        public bool AddGuest(GuestDTO guest, out string errorMessage)
        {
            //Implement check if guest is already on the list here and adjust rest of logic accordingly
            string errorM = "";
            errorMessage = errorM;

            _guestDb.GuestList.Add(new Guest(guest.Name, guest.Surname, guest.Gender));

            return true;
        }
    }
}
