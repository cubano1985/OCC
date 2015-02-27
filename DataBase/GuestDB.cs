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
        public List<Guest> GuestList { get; set; }
    }
}
