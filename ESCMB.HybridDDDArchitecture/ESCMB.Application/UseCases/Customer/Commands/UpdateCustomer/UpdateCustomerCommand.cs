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
        public string Id { get; set; }
      
        public string CuilCuit { get; set; }
        [MaxLength(8)]
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }

        public UpdateCustomerCommand()
        {
        }
    }
}
