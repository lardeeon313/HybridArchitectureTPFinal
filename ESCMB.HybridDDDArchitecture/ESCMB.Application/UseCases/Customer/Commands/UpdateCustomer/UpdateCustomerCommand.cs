using Core.Application.ComandQueryBus.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.UseCases.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequestCommand<Unit>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DummyPropertyTwo { get; set; }
        public DummyValues DummyPropertyThree { get; set; }

        public UpdateCustomerCommand()
        {
        }
    }
}
