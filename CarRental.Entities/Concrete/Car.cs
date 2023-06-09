using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Car : AuditableEntity
    {

        
        public int ModelId { get; set; }

        public Model Model { get; set; }

        public int ColorId { get; set; }

        public Color Color { get; set; }

        public int Year { get; set; }
        public decimal Price { get; set; }


    }
}
