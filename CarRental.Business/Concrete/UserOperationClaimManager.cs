using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.DTOs.UserOperationClaimDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        //Todo : Role değiştirme controller eklenecek 

        IUserOperationClaimRepository _userOperationClaimRepository;
        IUserRepository _userRepository;
        IOperationClaimRepository _operationClaimRepository;
        IMapper _mapper; 

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<IResult> AddAsync(UserOperationClaimAddDto entity)
        {
            var newUserOperationClaim = _mapper.Map<UserOperationClaim>(entity);

            newUserOperationClaim.CreatedDate = DateTime.Now;
         



         await _userOperationClaimRepository.AddAsync(newUserOperationClaim);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _userOperationClaimRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<UserOperationClaimDetailDto>> GetAsync(Expression<Func<UserOperationClaim, bool>> filter)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(filter);
            if (userOperationClaim != null)
            {
                var userOperationClaimDetailDto = await AssignOperationClaimDetails(userOperationClaim, userOperationClaim.UserId, userOperationClaim.OperationClaimId);
                return new SuccessDataResult<UserOperationClaimDetailDto>(userOperationClaimDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<UserOperationClaimDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<UserOperationClaimDetailDto>> GetByIdAsync(int id)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == id);
            if (userOperationClaim != null)
            {
                var userOperationClaimDetailDto = await AssignOperationClaimDetails(userOperationClaim, userOperationClaim.UserId, userOperationClaim.OperationClaimId);
                return new SuccessDataResult<UserOperationClaimDetailDto>(userOperationClaimDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<UserOperationClaimDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<UserOperationClaimDetailDto>>> GetListAsync(Expression<Func<UserOperationClaim, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _userOperationClaimRepository.GetListAsync();
                var responseUserOperationDetailDto = _mapper.Map<IEnumerable<UserOperationClaimDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<UserOperationClaimDetailDto>>(responseUserOperationDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _userOperationClaimRepository.GetListAsync(filter);
                var responseUserOperationDetailDto = _mapper.Map<IEnumerable<UserOperationClaimDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<UserOperationClaimDetailDto>>(responseUserOperationDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<UserOperationClaimUpdateDto>> UpdateAsync(UserOperationClaimUpdateDto userOperationClaimUpdateDto)
        {
            var getUserOperation = await _userOperationClaimRepository.GetAsync(x => x.Id == userOperationClaimUpdateDto.Id);

            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimUpdateDto);


            userOperationClaim.UpdatedDate = DateTime.Now;
            userOperationClaim.UpdatedBy = 1;


            var userOperationUpdate = await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
            var resultUpdateDto = _mapper.Map<UserOperationClaimUpdateDto>(userOperationUpdate);

            return new SuccessDataResult<UserOperationClaimUpdateDto>(resultUpdateDto, Messages.Updated);
        }
        private async Task<UserOperationClaimDetailDto> AssignOperationClaimDetails(UserOperationClaim userOperationClaim, int userId, int operationClaimId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == operationClaimId);
         
            if (user == null || operationClaim == null )
            {
                return null;
            }

            userOperationClaim.User = user;
            userOperationClaim.OperationClaim = operationClaim;
           
            var userOperationClaimDto = _mapper.Map<UserOperationClaimDetailDto>(userOperationClaim);
            return userOperationClaimDto;
        }

    }
}
