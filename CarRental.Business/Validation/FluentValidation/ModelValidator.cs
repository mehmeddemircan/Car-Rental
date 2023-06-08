using CarRental.Entities.DTOs.ModelDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Validation.FluentValidation
{
    public class ModelValidator : AbstractValidator<ModelAddDto>
    {

        public ModelValidator()
        {
            RuleFor(x => x.ModelName).MinimumLength(1).WithMessage("Geçersiz uzunlukta bir marka ismi girdiniz tekrar deneyiniz");
        }
    }
}
