using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.Validation.FluentValidation;
using CarRental.Core.Aspects.Validation;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.PackageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class PackageManager : IPackageService
    {
        IPackageRepository _packageRepository;
        IMapper _mapper;

        public PackageManager(IPackageRepository packageRepository , IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;   
        }

        [ValidationAspect(typeof(PackageValidator))]
        public async Task<IResult> AddAsync(PackageAddDto entity)
        {
            var newPackage = _mapper.Map<Package>(entity);

            newPackage.CreatedDate = DateTime.Now;


            await _packageRepository.AddAsync(newPackage);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _packageRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<PackageDetailDto>> GetAsync(Expression<Func<Package, bool>> filter)
        {
            var package = await _packageRepository.GetAsync(filter);
            if (package != null)
            {
                var packageDto = _mapper.Map<PackageDetailDto>(package);
                return new SuccessDataResult<PackageDetailDto>(packageDto, Messages.Listed);

            }
            return new ErrorDataResult<PackageDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<PackageDetailDto>> GetByIdAsync(int id)
        {
            var package = await _packageRepository.GetAsync(x => x.Id == id);
            if (package != null)
            {
                var packageDto = _mapper.Map<PackageDetailDto>(package);
                return new SuccessDataResult<PackageDetailDto>(packageDto, Messages.Listed);

            }
            return new ErrorDataResult<PackageDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<PackageDetailDto>>> GetListAsync(Expression<Func<Package, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _packageRepository.GetListAsync();
                var responsePackageDetailDto = _mapper.Map<IEnumerable<PackageDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<PackageDetailDto>>(responsePackageDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _packageRepository.GetListAsync(filter);
                var responsePackageDetailDto = _mapper.Map<IEnumerable<PackageDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<PackageDetailDto>>(responsePackageDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<PackageUpdateDto>> UpdateAsync(PackageUpdateDto packageUpdateDto)
        {
            var getPackage = await _packageRepository.GetAsync(x => x.Id == packageUpdateDto.Id);

            var package = _mapper.Map<Package>(packageUpdateDto);


            package.UpdatedDate = DateTime.Now;
            package.UpdatedBy = 1;


            var packageUpdate = await _packageRepository.UpdateAsync(package);
            var resultUpdateDto = _mapper.Map<PackageUpdateDto>(packageUpdate);

            return new SuccessDataResult<PackageUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
