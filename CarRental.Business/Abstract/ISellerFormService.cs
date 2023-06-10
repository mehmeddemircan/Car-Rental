using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.SellerFormDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ISellerFormService
    {
        Task<IResult> AddAsync(SellerFormAddDto entity);


        Task<IDataResult<IEnumerable<SellerFormDetailDto>>> GetListAsync(Expression<Func<SellerForm, bool>> filter = null);
        Task<IDataResult<SellerFormDetailDto>> GetAsync(Expression<Func<SellerForm, bool>> filter);

        Task<IDataResult<SellerFormDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<SellerFormUpdateDto>> UpdateAsync(SellerFormUpdateDto sellerFormUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
