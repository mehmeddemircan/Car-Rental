﻿using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.UserDtos
{
    public class UserDetailDto : IDto
    {

        public string Username { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
