using Core.Application.ComandQueryBus.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.UseCases.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequestCommand<string>
    {
        [Required]
        public string Id { get; private set; }
        [Required]
        public string CuilCuit { get; private set; }
        [Required]
        public string DocumentNumber { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public bool EmailConfirmed { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public CustomerStatus Status { get; private set; }

        public CreateCustomerCommand()
        {
            
        }

    }
}
