﻿using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CompanyDtos
{
    public class CompanyAddDto : IDto
    {

        public string CompanyName { get; set; }

        public int UserId { get; set; }
    }
}
