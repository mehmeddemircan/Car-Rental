using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Core.Aspects.Logging;
using CarRental.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {

        IOperationClaimRepository _operationClaimRepository;

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<IResult> AddAsync(OperationClaim entity)
        {
            await _operationClaimRepository.AddAsync(entity);

            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _operationClaimRepository.DeleteAsync(id);

            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        //[LogAspect(typeof(FileLogger))]

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetAllAsync(Expression<Func<OperationClaim, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _operationClaimRepository.GetListAsync();


                return new SuccessDataResult<IEnumerable<OperationClaim>>(response, Messages.Listed);
            }
            else
            {
                var response = await _operationClaimRepository.GetListAsync(filter);


                return new SuccessDataResult<IEnumerable<OperationClaim>>(response, Messages.Listed);
            }
        }

        public async Task<IDataResult<OperationClaim>> GetSingleAsync(Expression<Func<OperationClaim, bool>> filter)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(filter);

            if (operationClaim != null)
            {

             
                return new SuccessDataResult<OperationClaim>(operationClaim, Messages.Listed);
            }
            return new ErrorDataResult<OperationClaim>(null, Messages.NotListed);
        }

        public async Task<IResult> UpdateAsync(OperationClaim entity)
        {
            await _operationClaimRepository.UpdateAsync(entity);

            return new SuccessResult(Messages.Updated);
        }
    }
}
