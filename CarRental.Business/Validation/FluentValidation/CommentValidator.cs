using CarRental.Entities.DTOs.CommentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Validation.FluentValidation
{
    public class CommentValidator : AbstractValidator<CommentAddDto>
    {

        public CommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Yorum içeriği boş bırakılamaz !");
        }
    }

}
