using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Brand : AuditableEntity
    {

        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
