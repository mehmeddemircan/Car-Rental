using CarRental.Core.Entities.Concrete;
using CarRental.Core.Entities.Concrete.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Rental : AuditableEntity
    {
     
         
            public int CarId { get; set; }
            public virtual Car Car { get; set; }
            public int UserId { get; set; }

            public virtual User User { get; set; }

            public DateTime RentDate { get; set; }
            public DateTime? ReturnDate { get; set; }
        }
    
}
