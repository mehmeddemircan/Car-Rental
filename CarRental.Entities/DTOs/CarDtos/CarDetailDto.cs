using CarRental.Core.Entities.Abstract;
using CarRental.Entities.DTOs.ColorDtos;
using CarRental.Entities.DTOs.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CarDtos
{
    public class CarDetailDto  : IDto
    {

        public int Id { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }

        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int Year { get; set; }

        public string Description { get; set; }
        public int DailyPrice { get; set; }

    }
}
