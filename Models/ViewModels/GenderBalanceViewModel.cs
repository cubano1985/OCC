using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models.ViewModels
{
    public class GenderBalanceViewModel
    {
        public int MenInvited { get; set; }
        public int WomenInvited { get; set; }
        public int MenAttending { get; set; }
        public int WomenAttending { get; set; }
        public string InvitedWarning { get; set; }
        public string AttendingWarning { get; set; }
    }
}
