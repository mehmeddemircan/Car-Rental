using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.ModelDtos
{
    public class ModelUpdateDto : IDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
    }
}
