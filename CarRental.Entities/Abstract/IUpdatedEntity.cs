using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Abstract
{
    public interface IUpdatedEntity 
    {

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
