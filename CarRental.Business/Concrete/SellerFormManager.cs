using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.SellerFormDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class SellerFormManager : ISellerFormService
    {

        ISellerFormRepository _sellerFormRepository;
        IMapper _mapper;

        public SellerFormManager(ISellerFormRepository sellerFormRepository , IMapper mapper)
        {
            _sellerFormRepository = sellerFormRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(SellerFormAddDto entity)
        {
            var newForm = _mapper.Map<SellerForm>(entity);

            newForm.CreatedDate = DateTime.Now;




          await _sellerFormRepository.AddAsync(newForm);
         

            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _sellerFormRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<SellerFormDetailDto>> GetAsync(Expression<Func<SellerForm, bool>> filter)
        {
            var sellerForm = await _sellerFormRepository.GetAsync(filter);
            if (sellerForm != null)
            {
                var sellerFormDto = _mapper.Map<SellerFormDetailDto>(sellerForm);
                return new SuccessDataResult<SellerFormDetailDto>(sellerFormDto, Messages.Listed);

            }
            return new ErrorDataResult<SellerFormDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<SellerFormDetailDto>> GetByIdAsync(int id)
        {
            var sellerForm = await _sellerFormRepository.GetAsync(x => x.Id == id);
            if (sellerForm != null)
            {
                var sellerFormDto = _mapper.Map<SellerFormDetailDto>(sellerForm);
                return new SuccessDataResult<SellerFormDetailDto>(sellerFormDto, Messages.Listed);

            }
            return new ErrorDataResult<SellerFormDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<SellerFormDetailDto>>> GetListAsync(Expression<Func<SellerForm, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _sellerFormRepository.GetListAsync();
                var responseSellerFormDetailDto = _mapper.Map<IEnumerable<SellerFormDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<SellerFormDetailDto>>(responseSellerFormDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _sellerFormRepository.GetListAsync(filter);
                var responseSellerFormDetailDto = _mapper.Map<IEnumerable<SellerFormDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<SellerFormDetailDto>>(responseSellerFormDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<SellerFormUpdateDto>> UpdateAsync(SellerFormUpdateDto sellerFormUpdateDto)
        {
            var getSellerForm = await _sellerFormRepository.GetAsync(x => x.Id == sellerFormUpdateDto.Id);

            var sellerForm = _mapper.Map<SellerForm>(sellerFormUpdateDto);


            sellerForm.UpdatedDate = DateTime.Now;
            sellerForm.UpdatedBy = 1;


            var sellerFormUpdate = await _sellerFormRepository.UpdateAsync(sellerForm);
            var resultUpdateDto = _mapper.Map<SellerFormUpdateDto>(sellerFormUpdate);

            return new SuccessDataResult<SellerFormUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
