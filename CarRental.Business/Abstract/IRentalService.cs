using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.RentalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IRentalService 
    {

        Task<IResult> AddAsync(RentalAddDto entity);


        Task<IDataResult<IEnumerable<RentalDetailDto>>> GetListAsync(Expression<Func<Rental, bool>> filter = null);
        Task<IDataResult<RentalDetailDto>> GetAsync(Expression<Func<Rental, bool>> filter);

        Task<IDataResult<RentalDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<RentalUpdateDto>> UpdateAsync(RentalUpdateDto rentalUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
