using Core.Application.ComandQueryBus.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequestCommand<Unit>
    {
        [Required]
        public int Id { get; set; }

        public DeleteCustomerCommand()
        {
            
        }
    }
    
}
