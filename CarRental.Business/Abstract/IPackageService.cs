using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.PackageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IPackageService
    {

        Task<IResult> AddAsync(PackageAddDto entity);


        Task<IDataResult<IEnumerable<PackageDetailDto>>> GetListAsync(Expression<Func<Package, bool>> filter = null);
        Task<IDataResult<PackageDetailDto>> GetAsync(Expression<Func<Package, bool>> filter);

        Task<IDataResult<PackageDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<PackageUpdateDto>> UpdateAsync(PackageUpdateDto packageUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);

    }
}
