using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.Contexts;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class ColorRepository : EfBaseRepository<Color,ApplicationDbContext> , IColorRepository
    {
    }
}
