using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Aspects.Transaction;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorRepository _colorRepository;
        IMapper _mapper; 
        public ColorManager(IColorRepository colorRepository,IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        //[TransactionScopeAspect]
        public async Task<IDataResult<ColorDetailDto>> AddAsync(ColorAddDto entity)
        {
            var newColor = _mapper.Map<Color>(entity);

            var colorAdd = await _colorRepository.AddAsync(newColor);
            // Fetch the brand from the database based on the BrandID

            //throw new Exception("Hata Oluştu");

            var colorDto = _mapper.Map<ColorDetailDto>(colorAdd);

            return new SuccessDataResult<ColorDetailDto>(colorDto, Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {

            var isDelete = await _colorRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);

        }

        public async Task<IDataResult<ColorDetailDto>> GetAsync(Expression<Func<Color, bool>> filter)
        {
            var color = await _colorRepository.GetAsync(filter);
            if (color != null)
            {
                var colorDto = _mapper.Map<ColorDetailDto>(color);
                return new SuccessDataResult<ColorDetailDto>(colorDto, Messages.Listed);

            }
            return new ErrorDataResult<ColorDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<ColorDetailDto>> GetByIdAsync(int id)
        {
            var color = await _colorRepository.GetAsync(x => x.Id == id);
            if (color != null)
            {
                var colorDto = _mapper.Map<ColorDetailDto>(color);
                return new SuccessDataResult<ColorDetailDto>(colorDto, Messages.Listed);
            }
            return new ErrorDataResult<ColorDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<ColorDetailDto>>> GetListAsync(Expression<Func<Color, bool>> filter = null)
        {

            if (filter == null)
            {

                var response = await _colorRepository.GetListAsync();

                var responseColorDetailDto = _mapper.Map<IEnumerable<ColorDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<ColorDetailDto>>(responseColorDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _colorRepository.GetListAsync(filter);

                var responseColorDetailDto = _mapper.Map<IEnumerable<ColorDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<ColorDetailDto>>(responseColorDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<IEnumerable<ColorDetailDto>>> GetListAsyncPagination(int pageNumber, int pageSize, Expression<Func<Color, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _colorRepository.GetListAsyncPagination(pageNumber,pageSize);

                var responseColorDetailDto = _mapper.Map<IEnumerable<ColorDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<ColorDetailDto>>(responseColorDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _colorRepository.GetListAsyncPagination(pageNumber,pageSize,filter);

                var responseColorDetailDto = _mapper.Map<IEnumerable<ColorDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<ColorDetailDto>>(responseColorDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<ColorUpdateDto>> UpdateAsync(ColorUpdateDto colorUpdateDto)
        {
            var getModel = await _colorRepository.GetAsync(x => x.Id == colorUpdateDto.Id);

            var color = _mapper.Map<Color>(colorUpdateDto);


            color.UpdatedDate = DateTime.Now;
            color.UpdatedBy = 1;


            var colorUpdate = await _colorRepository.UpdateAsync(color);
            var resultUpdateDto = _mapper.Map<ColorUpdateDto>(colorUpdate);

            return new SuccessDataResult<ColorUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
