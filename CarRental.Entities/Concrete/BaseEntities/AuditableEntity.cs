using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete.BaseEntities
{
    public class AuditableEntity : BaseEntity , ICreatedEntity , IUpdatedEntity
    {


        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
