﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.DataTransferObjects;


namespace Services
{
    public interface IGuestService
    {
        List<Guest> GetGuestList();
        bool AddGuest(GuestDTO guest, out string errorMessage);
       
    }
}
