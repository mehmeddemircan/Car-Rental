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

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int ColorId { get; set; }

        public  virtual Color Color { get; set; }

        public string Description { get; set; }
        public int Year { get; set; }
        public int DailyPrice { get; set; }


    }
}
