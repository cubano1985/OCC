﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    [Serializable]
    public class Guest
    {
        //Static enumerator for Guests on the List
        private static int idOrder = 1;
        [Key]
        public int Id { get; set; }
        [Required]        
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public GuestGender Gender { get; set; }
        public GuestStatus Status { get; set; }

        public Guest() { }

        public Guest(string name, string surname, GuestGender gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;

            this.Status = GuestStatus.Invited;
            this.Id = idOrder++;
        }

        public Guest(string name, string surname, GuestGender gender, GuestStatus status):this(name, surname, gender)
        {
            this.Status = status;
            this.Id = idOrder++;
        }
    }
}
