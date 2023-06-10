using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.PackageDtos
{
    public class PackageDetailDto : IDto
    {

        public int Id { get; set; }

        public string PackageName { get; set; }

        public int ModelId { get; set; }
    }
}
