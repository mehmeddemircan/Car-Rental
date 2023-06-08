using CarRental.Entities.DTOs.BrandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Validation.FluentValidation
{
    public class BrandValidator : AbstractValidator<BrandAddDto>
    {

        public BrandValidator()
        {
            RuleFor(x => x.BrandName).MinimumLength(1).WithMessage("Geçersiz uzunlukta bir marka ismi girdiniz tekrar deneyiniz");
        }
    }
}
