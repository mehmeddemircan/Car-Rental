using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.BrandDtos
{
    public class BrandAddDto : IDto
    {

        public string BrandName { get; set; }
    }
}
