﻿using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CarDtos
{
    public class CarUpdateDto : IDto
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int PackageId { get; set; }
        public int ColorId { get; set; }
        public int Year { get; set; }
        public int DailyPrice { get; set; }
    }
}
