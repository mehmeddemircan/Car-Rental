using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.PackageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class PackageProfile : Profile
    {

        public PackageProfile()
        {
            CreateMap<PackageAddDto, Package>();
            CreateMap<Package, PackageAddDto>();

            CreateMap<PackageUpdateDto, Package>();
            CreateMap<Package, PackageUpdateDto>();

            CreateMap<PackageDetailDto, Package>();
            CreateMap<Package, PackageDetailDto>();
        }
    }
}
