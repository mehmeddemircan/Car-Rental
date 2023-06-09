using CarRental.Entities.DTOs.CarDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Validation.FluentValidation
{
    public class CarValidator : AbstractValidator<CarAddDto>
    {

        public CarValidator()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş gecilemez !");
        }
    }
}
