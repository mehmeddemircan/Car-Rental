using CarRental.Core.Entities.Abstract;
using CarRental.Entities.DTOs.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.CompanyDtos
{
    public class CompanyDetailDto : IDto
    {

        public int Id { get; set; }

        public string CompanyName { get; set; }

        //Todo : CarBrand oluşturulacak 
        //public ICollection<BrandDetailDto> MyProperty { get; set; }

    }
}
