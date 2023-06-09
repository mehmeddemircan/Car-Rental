using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Model : AuditableEntity
    {
     
        public string ModelName { get; set; }
        public int BrandId { get; set; }
     
    }
}
