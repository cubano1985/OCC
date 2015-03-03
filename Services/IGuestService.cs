using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.DataTransferObjects;
using Models.ViewModels;


namespace Services
{
    public interface IGuestService
    {
        List<Guest> GetGuestList();

        void AddGuest(GuestDTO guest);

        void ChangeStatus(int guestId, string newStatus);

        GenderBalanceViewModel GetGenderBalanceViewModel();

        void DeleteGuest(int id);
    }
}
