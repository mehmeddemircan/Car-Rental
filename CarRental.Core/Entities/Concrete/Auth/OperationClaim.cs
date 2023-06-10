using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities.Concrete.Auth
{
    public class OperationClaim : AuditableEntity
    {

        public string Name { get; set; }
    }
}
