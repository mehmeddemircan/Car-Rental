using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.Validation.FluentValidation;
using CarRental.Core.Aspects.Validation;
using CarRental.Core.Utilities.Business;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.BrandDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandRepository _brandRepository;
        ICloudinaryService _cloudinaryService;
        IMapper _mapper; 
        public BrandManager(IBrandRepository brandRepository, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public async Task<IResult> AddAsync(BrandAddDto entity)
        {

            IResult result = BusinessRules.Run(CheckIfBrandName(entity.BrandName));

            if (result != null)
            {
                return result;
            }

            var newBrand = _mapper.Map<Brand>(entity);

            //newBrand.CreatedDate = DateTime.Now;
            var imageUrl = await UploadImageAsync(entity.Image);
            newBrand.ImageUrl = imageUrl;



            var brandAdd = await _brandRepository.AddAsync(newBrand);
            var brandDto = _mapper.Map<BrandDetailDto>(brandAdd);

            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _brandRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);

        }

        public async Task<IDataResult<BrandDetailDto>> GetAsync(Expression<Func<Brand, bool>> filter)
        {
            var brand = await _brandRepository.GetAsync(filter);
            if (brand != null)
            {
                var brandDto = _mapper.Map<BrandDetailDto>(brand);
                return new SuccessDataResult<BrandDetailDto>(brandDto, Messages.Listed);

            }
            return new ErrorDataResult<BrandDetailDto>(null,Messages.NotListed);
        }

        public async Task<IDataResult<BrandDetailDto>> GetByIdAsync(int id)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == id);
            if (brand != null)
            {
                var brandDto = _mapper.Map<BrandDetailDto>(brand);
                return new SuccessDataResult<BrandDetailDto>(brandDto, Messages.Listed);
            }
            return new ErrorDataResult<BrandDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<BrandDetailDto>>> GetListAsync(Expression<Func<Brand, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _brandRepository.GetListAsync();
                var responseBrandDetailDto = _mapper.Map<IEnumerable<BrandDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<BrandDetailDto>>(responseBrandDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _brandRepository.GetListAsync(filter);
                var responseBrandDetailDto = _mapper.Map<IEnumerable<BrandDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<BrandDetailDto>>(responseBrandDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<BrandUpdateDto>> UpdateAsync(BrandUpdateDto brandUpdateDto)
        {
            var getBrand = await _brandRepository.GetAsync(x => x.Id == brandUpdateDto.Id);

            var brand = _mapper.Map<Brand>(brandUpdateDto);

            var imageUrl = await UploadImageAsync(brandUpdateDto.Image);
            brand.ImageUrl = imageUrl;
            brand.UpdatedDate = DateTime.Now;
            brand.UpdatedBy = 1;


            var brandUpdate = await _brandRepository.UpdateAsync(brand);
            var resultUpdateDto = _mapper.Map<BrandUpdateDto>(brandUpdate);

            return new SuccessDataResult<BrandUpdateDto>(resultUpdateDto, Messages.Updated);
        }

        private async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            var imagePath = Path.GetTempFileName(); // Get a temporary file path to store the uploaded image
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            var imageUrl = await _cloudinaryService.UploadImageAsync(imagePath);

            // Delete the temporary image file
            System.IO.File.Delete(imagePath);

            return imageUrl;
        }

        private IResult CheckIfBrandName(string brandName)
        {
            var result = _brandRepository.GetListAsync(m => m.BrandName == brandName).Result.Any();

            if (result)
            {
                return new ErrorResult("zaten var bu isimde");
            }
            return new SuccessResult("basarili şekilde eklendi");
        }
    }
}
