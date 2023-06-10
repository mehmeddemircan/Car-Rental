using CarRental.Core.DataAccess.EntityFramework;
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class UserOperationClaimRepository : EfBaseRepository<UserOperationClaim,ApplicationDbContext> , IUserOperationClaimRepository
    {
    }
}
