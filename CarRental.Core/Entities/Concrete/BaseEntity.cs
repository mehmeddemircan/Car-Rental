
using CarRental.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities.Concrete
{
    public class BaseEntity : IEntity
    {
       
        public int Id { get; set; }
    }
}
