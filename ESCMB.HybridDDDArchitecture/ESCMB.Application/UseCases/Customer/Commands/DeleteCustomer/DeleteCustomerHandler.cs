using Core.Application.ComandQueryBus.Buses;
using Core.Application.ComandQueryBus.Commands;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.DomainEvents.Customer;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity;
using ESCMB.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Commands.DeleteCustomer
{
    internal sealed class DeleteCustomerHandler(ICommandQueryBus domainBus, ICustomerRepository customerRepository)
        : IRequestCommandHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly ICustomerRepository _context = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Llego");
                
                _context.Remove(await _context.FindOneAsync(request.Id));

                _domainBus.Publish(new CustomerDeleted(request.Id), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar cliente " + ex);
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
