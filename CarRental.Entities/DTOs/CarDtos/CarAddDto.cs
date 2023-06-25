using CarRental.Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CarDtos
{
    public class CarAddDto : IDto
    {
        public int CompanyId { get; set; }

        public string Description { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }

        public int PackageId { get; set; }
        public int ColorId { get; set; }
        public int Year { get; set; }
        public int DailyPrice { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
