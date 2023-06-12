using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IColorService
    {

        Task<IDataResult<ColorDetailDto>> AddAsync(ColorAddDto entity);


        Task<IDataResult<IEnumerable<ColorDetailDto>>> GetListAsync(Expression<Func<Color, bool>> filter = null);
        Task<IDataResult<ColorDetailDto>> GetAsync(Expression<Func<Color, bool>> filter);

        Task<IDataResult<ColorDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<ColorUpdateDto>> UpdateAsync(ColorUpdateDto colorUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);

        Task<IDataResult<IEnumerable<ColorDetailDto>>> GetListAsyncPagination(int pageNumber,int pageSize,Expression<Func<Color,bool>> filter= null);
    }
}
