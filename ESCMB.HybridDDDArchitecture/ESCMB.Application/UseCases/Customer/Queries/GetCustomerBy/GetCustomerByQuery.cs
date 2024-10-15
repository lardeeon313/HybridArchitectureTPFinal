using ESCMB.Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Queries.GetCustomerBy
{
    public class GetCustomerByQuery : IRequest<CustomerDto>
    {
        [Required]
        public string Id { get; set; }

        public GetCustomerByQuery()
        {
            
        }
    }
}
