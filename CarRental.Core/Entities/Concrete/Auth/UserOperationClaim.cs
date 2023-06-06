using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities.Concrete.Auth
{
    public class UserOperationClaim : AuditableEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
