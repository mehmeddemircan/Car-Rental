﻿using CarRental.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Car : AuditableEntity
    {

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        public int ColorId { get; set; }

        public  virtual Color Color { get; set; }

        public string Description { get; set; }
        public int Year { get; set; }
        public int DailyPrice { get; set; }
        public List<CarImage> Images { get; set; } 
        public virtual ICollection<Comment> Comments { get; set; }
    }
   
    public class CarImage : AuditableEntity
    {
        public int CarId { get; set; }
        public string? PublicId { get; set; }
        public string Url { get; set; }
    }
}
