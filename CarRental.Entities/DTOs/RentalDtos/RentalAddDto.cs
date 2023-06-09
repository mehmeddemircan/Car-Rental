using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.RentalDtos
{
    public class RentalAddDto  : IDto
    {

        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
    }
}
