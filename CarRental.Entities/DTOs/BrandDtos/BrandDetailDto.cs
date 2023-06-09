using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.BrandDtos
{
    public class BrandDetailDto  : IDto
    {

        public int Id { get; set; }

        public string BrandName { get; set; }

        public string ImageUrl { get; set; }

    }
}
