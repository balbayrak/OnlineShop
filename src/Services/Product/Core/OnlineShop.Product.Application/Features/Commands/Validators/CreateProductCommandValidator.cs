using FluentValidation;
using OnlineShop.Product.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Product.Application.Features.Commands.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Dto).NotEmpty().WithMessage(ExceptionMessages.PRODUCT_CREATEDTO_NOT_EMPTY);
            RuleFor(p => p.Dto.Name).NotEmpty().WithMessage(ExceptionMessages.PRODUCT_NAME_EMPTY);
            RuleFor(p => p.Dto.Code).NotEmpty().WithMessage(ExceptionMessages.PRODUCT_CODE_EMPTY);

        }
    }
}
