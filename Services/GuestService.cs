using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.DataTransferObjects;
using DataBase;
using Models.ViewModels;

namespace Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestDb _guestDb;

        public GuestService(IGuestDb guestDb)
        {
            _guestDb = guestDb;
        }

        /// <summary>
        /// Method that connects to Database to get Guest List.
        /// </summary>
        /// <returns>Full Guest List</returns>
        public List<Guest> GetGuestList()
        {
            var response = _guestDb.GuestList;
            return response;
        }

        /// <summary>
        /// Method that adds Guest to the Database
        /// </summary>
        /// <param name="guest">Input value from user</param>                
        public void AddGuest(GuestDTO guest)
        {            
            var checkIfGuestIsAlreadyInDb = _guestDb.GuestList.Where(anyGuest => anyGuest.Name.ToLower() == guest.Name.ToLower())
                                                .Any(anyGuest => anyGuest.Surname.ToLower() == guest.Surname.ToLower());

            if (!checkIfGuestIsAlreadyInDb)
            {
                _guestDb.GuestList.Add(new Guest(guest.Name, guest.Surname, guest.Gender));
            }
                        
        }

        /// <summary>
        /// Method that changes Status of Guest
        /// </summary>
        /// <param name="guestId">To which Guest status should be changed</param>
        /// <param name="newStatus">New status name</param>
        public void ChangeStatus(int guestId, string newStatus)
        {
            var guest = _guestDb.GuestList.First(guestById => guestById.Id == guestId);
            switch (newStatus)
            {
                case "Invited":
                    guest.Status = GuestStatus.Invited;
                    break;
                case "Attending":
                    guest.Status = GuestStatus.Attending;
                    break;
                case "NotAttending":
                    guest.Status = GuestStatus.NotAttending;
                    break;
            }
        }

        /// <summary>
        /// Method that creates GenderBalanceViewModel.
        /// </summary>
        /// <returns>GenderBalanceViewModel</returns>
        public GenderBalanceViewModel GetGenderBalanceViewModel()
        {
            var viewModel = new GenderBalanceViewModel();
            var guestList = _guestDb.GuestList;

            viewModel.MenInvited = guestList.Where(selectMen => selectMen.Gender == GuestGender.Male)
                                            .Where(selectInvited => selectInvited.Status == GuestStatus.Invited)
                                            .ToList().Count;
            viewModel.WomenInvited = guestList.Where(selectWomen => selectWomen.Gender == GuestGender.Female)
                                            .Where(selectInvited => selectInvited.Status == GuestStatus.Invited)
                                            .ToList().Count;
            viewModel.MenAttending = guestList.Where(selectMen => selectMen.Gender == GuestGender.Male)
                                            .Where(selectAttending => selectAttending.Status == GuestStatus.Attending)
                                            .ToList().Count;
            viewModel.WomenAttending = guestList.Where(selectWomen => selectWomen.Gender == GuestGender.Female)
                                            .Where(selectAttending => selectAttending.Status == GuestStatus.Attending)
                                            .ToList().Count;

            var invitedVariation = Math.Abs(viewModel.MenInvited - viewModel.WomenInvited);
            var attendingVariation = Math.Abs(viewModel.WomenAttending - viewModel.MenAttending);

            switch (invitedVariation)
            {
                case 0:
                case 1:
                    break;
                case 2:
                case 3:
                case 4:
                    viewModel.InvitedWarning = "There is a small variations between Men and Women invited.";
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    viewModel.InvitedWarning = "There is medium variations between Men and Women invited.";
                    break;
                default:
                    viewModel.InvitedWarning = "There is major viriations between Men and Women invited. Please take action.";
                    break;
            }

            switch (attendingVariation)
            {
                case 0:
                case 1:
                    break;
                case 2:
                case 3:
                case 4:
                    viewModel.AttendingWarning = "There is a small variations between Men and Women attending.";
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    viewModel.AttendingWarning = "There is a noticible variations between Men and Women attending. Please take action.";
                    break;
                default:
                    viewModel.AttendingWarning = "There is major viriations between Men and Women attending. Please take action.";
                    break;
            }

            return viewModel;
        }

        /// <summary>
        /// Method that deletes guest from the list
        /// </summary>
        /// <param name="id">Guest id</param>
        public void DeleteGuest(int id)
        {
            var guest = _guestDb.GuestList.FirstOrDefault(guestById => guestById.Id == id);

            if (guest != null)
            {
                _guestDb.GuestList.Remove(guest);
            }
        }
    }
}
