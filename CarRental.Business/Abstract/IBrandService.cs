using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public  interface IBrandService 
    {
        Task<IDataResult<BrandDetailDto>> AddAsync(BrandAddDto entity);


        Task<IDataResult<IEnumerable<BrandDetailDto>>> GetListAsync(Expression<Func<Brand, bool>> filter = null);
        Task<IDataResult<BrandDetailDto>> GetAsync(Expression<Func<Brand, bool>> filter);

        Task<IDataResult<BrandDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<BrandUpdateDto>> UpdateAsync(BrandUpdateDto brandUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
