using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.Validation.FluentValidation;
using CarRental.Core.Aspects.Validation;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelRepository _modelRepository;
        IBrandRepository _brandRepository;
        IMapper _mapper; 
        public ModelManager(IModelRepository modelRepository, IMapper mapper, IBrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }


        [ValidationAspect(typeof(ModelValidator))]
        public async Task<IDataResult<ModelDetailDto>> AddAsync(ModelAddDto entity)
        {
            var newModel = _mapper.Map<Model>(entity);

            var modelAdd = await _modelRepository.AddAsync(newModel);
            // Fetch the brand from the database based on the BrandID
            bool brandAssigned = await CheckBrandId(entity.BrandId);

            if (!brandAssigned)
            {
                return new ErrorDataResult<ModelDetailDto>(null, "Geçersiz brand ID.");
            }



            var modelDto = await AssignBrandToModel(modelAdd,entity.BrandId);

            return new SuccessDataResult<ModelDetailDto>(modelDto, Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _modelRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<ModelDetailDto>> GetAsync(Expression<Func<Model, bool>> filter)
        {
            var model = await _modelRepository.GetAsync(filter);
            if (model != null)
            {

                // Fetch the brand from the database based on the BrandID
              var modelDto =  await  AssignBrandToModel(model, model.BrandId);

             

          
                
                
                return new SuccessDataResult<ModelDetailDto>(modelDto, Messages.Listed);

            }
            return new ErrorDataResult<ModelDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<ModelDetailDto>> GetByIdAsync(int id)
        {
            var model = await _modelRepository.GetAsync(x => x.Id == id);
            if (model != null)
            {

               var modelDto =   await AssignBrandToModel(model, model.BrandId);
               
                return new SuccessDataResult<ModelDetailDto>(modelDto, Messages.Listed);
            }
            return new ErrorDataResult<ModelDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<ModelListDto>>> GetListAsync(Expression<Func<Model, bool>> filter = null)
        {
           
            
            if (filter == null)
            {

                var response = await _modelRepository.GetListAsync();
                
                var responseModelDetailDto = _mapper.Map<IEnumerable<ModelListDto>>(response);
                return new SuccessDataResult<IEnumerable<ModelListDto>>(responseModelDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _modelRepository.GetListAsync(filter);
                var responseModelDetailDto = _mapper.Map<IEnumerable<ModelListDto>>(response);
                return new SuccessDataResult<IEnumerable<ModelListDto>>(responseModelDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<ModelUpdateDto>> UpdateAsync(ModelUpdateDto modelUpdateDto)
        {
            var getModel = await _modelRepository.GetAsync(x => x.Id == modelUpdateDto.Id);

            var model = _mapper.Map<Model>(modelUpdateDto);

          
            model.UpdatedDate = DateTime.Now;
            model.UpdatedBy = 1;


            var modelUpdate = await _modelRepository.UpdateAsync(model);
            var resultUpdateDto = _mapper.Map<ModelUpdateDto>(modelUpdate);

            return new SuccessDataResult<ModelUpdateDto>(resultUpdateDto, Messages.Updated);
        }
        private async Task<bool> CheckBrandId(int brandId)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == brandId);

            if (brand == null)
            {
                return false;
            }

           
            return true;
        }
        private async Task<ModelDetailDto> AssignBrandToModel(Model model, int brandId)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == brandId);

            if (brand == null)
            {
                return null;
            }

            
            var modelDetail = _mapper.Map<ModelDetailDto>(model);
            return modelDetail;
        }
    }
}
