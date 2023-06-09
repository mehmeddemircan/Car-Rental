using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICarService
    {

        Task<IDataResult<CarDetailDto>> AddAsync(CarAddDto entity);


        Task<IDataResult<IEnumerable<CarDetailDto>>> GetListAsync(Expression<Func<Car, bool>> filter = null);
        Task<IDataResult<CarDetailDto>> GetAsync(Expression<Func<Car, bool>> filter);

        Task<IDataResult<CarDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<CarUpdateDto>> UpdateAsync(CarUpdateDto carUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
