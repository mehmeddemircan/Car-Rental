using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Package  : AuditableEntity
    {

        public string PackageName { get; set; }

        public int ModelId { get; set; }
    }
}
