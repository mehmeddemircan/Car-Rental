using AutoMapper;
using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarRepository _carRepository;
        IModelRepository _modelRepository;
        IColorRepository _colorRepository;  
        IBrandRepository _brandRepository;
        IMapper _mapper; 
        public CarManager(ICarRepository carRepository, IMapper mapper, IModelRepository modelRepository, IColorRepository colorRepository, IBrandRepository brandRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _modelRepository = modelRepository;
            _colorRepository = colorRepository;
            _brandRepository = brandRepository;
        }
        public async Task<IDataResult<CarDetailDto>> AddAsync(CarAddDto entity)
        {
            var newCar = _mapper.Map<Car>(entity);

            var carAdd = await _carRepository.AddAsync(newCar);

            bool modelAssigned = await AssignModelToCar(carAdd, entity.ModelId);

            if (!modelAssigned)
            {
                return new ErrorDataResult<CarDetailDto>(null, "Geçersiz model ID.");
            }


            bool colorAssinged = await AssignColorToCar(carAdd, entity.ColorId);

            if (!colorAssinged)
            {
                return new ErrorDataResult<CarDetailDto>(null, "Geçersiz color ID.");
            }

            var carDto = _mapper.Map<CarDetailDto>(carAdd);

            return new SuccessDataResult<CarDetailDto>(carDto, Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _carRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);

        }

        public async Task<IDataResult<CarDetailDto>> GetAsync(Expression<Func<Car, bool>> filter)
        {
            var car = await _carRepository.GetAsync(filter);
            if (car != null)
            {

                // Fetch the brand from the database based on the BrandID
                await AssignModelToCar(car, car.ModelId);
                await AssignColorToCar(car, car.ColorId);


                var carDto = _mapper.Map<CarDetailDto>(car);


                return new SuccessDataResult<CarDetailDto>(carDto, Messages.Listed);

            }
            return new ErrorDataResult<CarDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CarDetailDto>> GetByIdAsync(int id)
        {
            var car = await _carRepository.GetAsync(x => x.Id == id);
            if (car != null)
            {

                await AssignModelToCar(car, car.ModelId);
                await AssignColorToCar(car, car.ColorId);
                var carDto = _mapper.Map<CarDetailDto>(car);
                return new SuccessDataResult<CarDetailDto>(carDto, Messages.Listed);
            }
            return new ErrorDataResult<CarDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetListAsync(Expression<Func<Car, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _carRepository.GetListAsync();

                var responseCarDetailDto = _mapper.Map<IEnumerable<CarDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CarDetailDto>>(responseCarDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _carRepository.GetListAsync(filter);

                var responseCarDetailDto = _mapper.Map<IEnumerable<CarDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CarDetailDto>>(responseCarDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<CarUpdateDto>> UpdateAsync(CarUpdateDto carUpdateDto)
        {
            var getCar = await _carRepository.GetAsync(x => x.Id == carUpdateDto.Id);

            var car = _mapper.Map<Car>(carUpdateDto);


            car.UpdatedDate = DateTime.Now;
            car.UpdatedBy = 1;


            var carUpdate = await _carRepository.UpdateAsync(car);
            var resultUpdateDto = _mapper.Map<CarUpdateDto>(carUpdate);

            return new SuccessDataResult<CarUpdateDto>(resultUpdateDto, Messages.Updated);
        }

        private async Task<bool> AssignModelToCar(Car car, int modelId)
        {
            var model = await _modelRepository.GetAsync(x => x.Id == modelId);
           
            if (model == null)
            {
                return false;
            }

            car.Model = model;
        
            return true;
        }

        private async Task<bool> AssignColorToCar(Car car, int colorId)
        {
            var color = await _colorRepository.GetAsync(x => x.Id == colorId);

            if (color == null)
            {
                return false;
            }

            car.Color = color;
            return true;
        }
    }
}
