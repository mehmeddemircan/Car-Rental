using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.RentalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalRepository _rentalRepository;
        IUserRepository _userRepository;
        ICarRepository _carRepository;
        IMapper _mapper; 
        public RentalManager(IRentalRepository rentalRepository, IMapper mapper, IUserRepository userRepository, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }
        public async Task<IResult> AddAsync(RentalAddDto entity)
        {
            var newRental = _mapper.Map<Rental>(entity);

            var rentalAdd = await _rentalRepository.AddAsync(newRental);
        

            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _rentalRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }
         

        public async Task<IDataResult<RentalDetailDto>> GetAsync(Expression<Func<Rental, bool>> filter)
        {
            var rental = await _rentalRepository.GetAsync(filter);
            if (rental != null)
            {

                // Fetch the brand from the database based on the BrandID


                var rentalDto = await AssignRentalDetails(rental, rental.CarId, rental.UserId);


                return new SuccessDataResult<RentalDetailDto>(rentalDto, Messages.Listed);

            }
            return new ErrorDataResult<RentalDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<RentalDetailDto>> GetByIdAsync(int id)
        {
            var rental = await _rentalRepository.GetAsync(x => x.Id == id);
            if (rental != null)
            {

                var rentalDto = await AssignRentalDetails(rental, rental.CarId, rental.UserId);

                return new SuccessDataResult<RentalDetailDto>(rentalDto, Messages.Listed);
            }
            return new ErrorDataResult<RentalDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<RentalDetailDto>>> GetListAsync(Expression<Func<Rental, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _rentalRepository.GetListAsync();

                var responseRentalDetailDto = _mapper.Map<IEnumerable<RentalDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<RentalDetailDto>>(responseRentalDetailDto, Messages.Listed);
            }
            else
            {

                var response = await _rentalRepository.GetListAsync(filter);

                var responseRentalDetailDto = _mapper.Map<IEnumerable<RentalDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<RentalDetailDto>>(responseRentalDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<RentalUpdateDto>> UpdateAsync(RentalUpdateDto rentalUpdateDto)
        {
            var getRental = await _rentalRepository.GetAsync(x => x.Id == rentalUpdateDto.Id);

            var rental = _mapper.Map<Car>(rentalUpdateDto);


            rental.UpdatedDate = DateTime.Now;
            rental.UpdatedBy = 1;


            var rentalUpdate = await _carRepository.UpdateAsync(rental);
            var resultUpdateDto = _mapper.Map<RentalUpdateDto>(rentalUpdate);

            return new SuccessDataResult<RentalUpdateDto>(resultUpdateDto, Messages.Updated);
        }
        private async Task<RentalDetailDto> AssignRentalDetails(Rental rental, int carId, int userId)
        {
            var car = await _carRepository.GetAsync(x => x.Id == carId);
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            
            if (car == null || user == null )
            {
                return null;
            }

            rental.Car= car;
            rental.User = user; 
            var rentalDetail = _mapper.Map<RentalDetailDto>(rental);
            return rentalDetail;
        }
    }
}
