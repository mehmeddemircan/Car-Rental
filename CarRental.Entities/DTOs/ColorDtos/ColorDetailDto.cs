using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.ColorDtos
{
    public class ColorDetailDto : IDto
    {

        public int Id { get; set; }

        public string ColorName { get; set; }
    }
}
