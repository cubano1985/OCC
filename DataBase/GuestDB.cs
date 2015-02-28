using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataBase
{
    public class GuestDb : IGuestDb
    {
        private static List<Guest> _guestList;
        
        public List<Guest> GuestList 
        {
            get { return _guestList; }
            set { _guestList = value; }
        }

        static GuestDb()
        {
            _guestList = new List<Guest>();
        }
    }
}
