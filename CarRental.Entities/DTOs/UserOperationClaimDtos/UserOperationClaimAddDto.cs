using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.DTOs.UserOperationClaimDtos
{
    public class UserOperationClaimAddDto : IDto
    {

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
