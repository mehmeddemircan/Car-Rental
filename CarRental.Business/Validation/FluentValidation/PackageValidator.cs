using CarRental.Entities.DTOs.PackageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Validation.FluentValidation
{
    public class PackageValidator : AbstractValidator<PackageAddDto>
    {

        public PackageValidator()
        {
            RuleFor(x => x.PackageName).NotEmpty().WithMessage("Paket ismi boş gecilemez ");
        }
    }

}
