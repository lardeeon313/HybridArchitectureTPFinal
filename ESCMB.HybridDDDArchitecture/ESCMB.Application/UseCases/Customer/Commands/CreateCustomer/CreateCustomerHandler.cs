using Core.Application.ComandQueryBus.Buses;
using Core.Application.ComandQueryBus.Commands;
using Core.Application.Mapping;
using ESCMB.Application.ApplicationServices;
using ESCMB.Application.ApplicationServices.Customer;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.DomainEvents.Customer;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Commands.CreateDummyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Commands.CreateCustomer
{
    public sealed class CreateCustomerHandler(ICommandQueryBus domainBus, ICustomerRepository customerRepository, ICustomerApplicationService customerApplicationService) : IRequestCommandHandler<CreateCustomerCommand, string>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly ICustomerRepository _context = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        private readonly ICustomerApplicationService _customerApplicationService = customerApplicationService ?? throw new ArgumentNullException(nameof(customerApplicationService));
        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer entity = new(request.CuilCuit, request.DocumentNumber, request.Email, request.FirstName, request.LastName);

            if (!entity.IsValid()) throw new InvalidEntityDataException(entity.GetErrors());

            if (_customerApplicationService.CustomerExist(entity.Id)) throw new EntityDoesExistException();

            try
            {
                string createdId = await _context.AddOneAsync(entity);

                await _domainBus.Publish(entity.To<CustomerCreated>(), cancellationToken);

                return createdId;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    } 
}
