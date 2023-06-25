using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CarDtos
{
    public class CarImageDto : IDto
    {

        public string PublicId { get; set; }

        public string Url { get; set; }
    }
}
