using CarRental.Core.Entities.Concrete;
using CarRental.Core.Entities.Concrete.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Company : AuditableEntity
    {

        public string CompanyName { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
