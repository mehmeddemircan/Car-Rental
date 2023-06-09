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

        public ModelDetailDto Model { get; set; }

        public ColorDetailDto Color { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

    }
}
