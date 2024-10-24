using Core.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Domain.Validators
{
    public class AccountValidator:EntityValidator<Account>
    {
        public AccountValidator()
        {
            /*
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.CBU).NotNull().NotEmpty().Length(22).WithMessage("El CBU debe tener exactamente 22 caracteres.");
            RuleFor(x => x.Alias).NotNull().NotEmpty().MaximumLength(20).WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.Monto).GreaterThanOrEqualTo(0).WithMessage("El monto debe ser mayor o igual a 0.");
            */
        }
    }
}
