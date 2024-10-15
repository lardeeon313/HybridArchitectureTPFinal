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
        public string CuilCuit { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool EmailConfirmed { get;  set; }
        [Required]
        public string FirstName { get;  set; }
        [Required]
        public string LastName { get;  set; }
        [Required]
        public CustomerStatus Status { get;  set; }

        public CreateCustomerCommand()
        {
            
        }

    }
}
