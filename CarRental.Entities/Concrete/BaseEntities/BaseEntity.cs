using CarRental.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete.BaseEntities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
