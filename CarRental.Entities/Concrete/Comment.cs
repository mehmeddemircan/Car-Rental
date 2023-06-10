using CarRental.Core.Entities.Concrete;
using CarRental.Core.Entities.Concrete.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entities.Concrete
{
    public class Comment : AuditableEntity
    {

        public string Content { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int CarId { get; set; } 
        public virtual Car Car { get; set; }
    }
}
