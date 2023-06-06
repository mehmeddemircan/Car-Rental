using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities.Abstract
{
    public interface ICreatedEntity
    {
        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
