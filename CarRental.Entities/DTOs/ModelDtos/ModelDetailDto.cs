using CarRental.Core.Entities.Abstract;
using CarRental.Entities.DTOs.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.ModelDtos
{
    public class ModelDetailDto : IDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        
        public BrandDetailDto Brand { get; set; }


    }
}
