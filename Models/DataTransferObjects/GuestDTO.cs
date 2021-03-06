﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.DataTransferObjects
{
    public class GuestDTO
    {
        [Required(ErrorMessage="Please enter guest Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter guest Surname")]
        public string Surname { get; set; }
        [Required]
        public GuestGender Gender { get; set; }

    }
}
