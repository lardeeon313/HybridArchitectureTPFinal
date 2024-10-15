using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;

namespace ESCMB.Domain.Validators
{
    public class CustomerValidator : EntityValidator<Customer>
    {
        public CustomerValidator()
        {
            //RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            //RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().MaximumLength(8).MinimumLength(7).WithMessage(Constants.NOTNULL_OR_EMPTY);
            //RuleFor(x => x.CuilCuit).MaximumLength(11).MinimumLength(11).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            //RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            //RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            //RuleFor(x => x.Status).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
        }
    }
}
