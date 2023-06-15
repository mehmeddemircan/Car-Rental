using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {

        ICompanyRepository _companyRepository;
        IMapper _mapper; 
        public CompanyManager(ICompanyRepository companyRepository,IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyRepository; 
        }
        public async Task<IResult> AddAsync(CompanyAddDto entity)
        {
            var newCompany = _mapper.Map<Company>(entity);

          await _companyRepository.AddAsync(newCompany);
            // Fetch the brand from the database based on the BrandID

            //throw new Exception("Hata Oluştu");


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _companyRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CompanyDetailDto>> GetAsync(Expression<Func<Company, bool>> filter)
        {
            var company = await _companyRepository.GetAsync(filter);
            if (company != null)
            {
                var companyDto = _mapper.Map<CompanyDetailDto>(company);
                return new SuccessDataResult<CompanyDetailDto>(companyDto, Messages.Listed);

            }
            return new ErrorDataResult<CompanyDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CompanyDetailDto>> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetAsync(x => x.Id == id);
            if (company != null)
            {
                var companyDto = _mapper.Map<CompanyDetailDto>(company);
                return new SuccessDataResult<CompanyDetailDto>(companyDto, Messages.Listed);

            }
            return new ErrorDataResult<CompanyDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CompanyDetailDto>>> GetListAsync(Expression<Func<Company, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _companyRepository.GetListAsync();
                var responseCompanyDetailDto = _mapper.Map<IEnumerable<CompanyDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CompanyDetailDto>>(responseCompanyDetailDto, Messages.Listed);
            }
            else
            {
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _companyRepository.GetListAsync(filter);
                var responseCompanyDetailDto = _mapper.Map<IEnumerable<CompanyDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CompanyDetailDto>>(responseCompanyDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<CompanyUpdateDto>> UpdateAsync(CompanyUpdateDto companyUpdateDto)
        {
            var getCompany = await _companyRepository.GetAsync(x => x.Id == companyUpdateDto.Id);

            var company = _mapper.Map<Company>(companyUpdateDto);


            company.UpdatedDate = DateTime.Now;
            company.UpdatedBy = 1;


            var companyUpdate = await _companyRepository.UpdateAsync(company);
            var resultUpdateDto = _mapper.Map<CompanyUpdateDto>(companyUpdate);

            return new SuccessDataResult<CompanyUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
