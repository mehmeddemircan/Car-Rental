using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IModelService
    {

        Task<IDataResult<ModelDetailDto>> AddAsync(ModelAddDto entity);


        Task<IDataResult<IEnumerable<ModelListDto>>> GetListAsync(Expression<Func<Model, bool>> filter = null);
        Task<IDataResult<ModelDetailDto>> GetAsync(Expression<Func<Model, bool>> filter);

        Task<IDataResult<ModelDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<ModelUpdateDto>> UpdateAsync(ModelUpdateDto modelUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
