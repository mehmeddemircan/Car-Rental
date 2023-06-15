using CarRental.Core.Utilities.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICompanyService
    {

        Task<IResult> AddAsync(CompanyAddDto entity);


        Task<IDataResult<IEnumerable<CompanyDetailDto>>> GetListAsync(Expression<Func<Company, bool>> filter = null);
        Task<IDataResult<CompanyDetailDto>> GetAsync(Expression<Func<Company, bool>> filter);

        Task<IDataResult<CompanyDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<CompanyUpdateDto>> UpdateAsync(CompanyUpdateDto companyUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
