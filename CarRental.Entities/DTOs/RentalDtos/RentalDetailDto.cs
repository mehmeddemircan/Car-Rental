using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.RentalDtos
{
    public class RentalDetailDto : IDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
     
        public string Description { get; set; }
        public int DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
