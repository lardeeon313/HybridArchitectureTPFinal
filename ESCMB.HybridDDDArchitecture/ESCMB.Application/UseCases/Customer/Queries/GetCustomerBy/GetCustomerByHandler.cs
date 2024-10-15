using Core.Application.ComandQueryBus.Queries;
using Core.Application.Mapping;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Queries.GetCustomerBy
{
    public class GetCustomerByHandler(ICustomerRepository context) : IRequestQueryHandler<GetCustomerByQuery, CustomerDto>
    {
        private readonly ICustomerRepository _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<CustomerDto> Handle(GetCustomerByQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine(request.Id);
                Domain.Entities.Customer entity = await _context.FindOneAsync(request.Id) ?? throw new EntityDoesNotExistException();
                Console.WriteLine("llego");
                return entity.To<CustomerDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
