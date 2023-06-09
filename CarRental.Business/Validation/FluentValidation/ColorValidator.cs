using CarRental.Entities.DTOs.ColorDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Validation.FluentValidation
{
    public class ColorValidator : AbstractValidator<ColorAddDto>
    {

        public ColorValidator()
        {
            RuleFor(x => x.ColorName).MinimumLength(1).WithMessage("Geçersiz uzunlukta bir marka ismi girdiniz tekrar deneyiniz");
        }
    }

}
