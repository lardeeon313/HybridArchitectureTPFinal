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
            Console.WriteLine("Creating customer entity...");
            Console.WriteLine("CUIT request" + request.CuilCuit);
            Domain.Entities.Customer entity = new(request.CuilCuit, request.DocumentNumber, request.Email, request.FirstName, request.LastName);

            if (!entity.IsValid())
            {
                Console.WriteLine("Customer entity is not valid");
                throw new InvalidEntityDataException(entity.GetErrors());
            }

            Console.WriteLine("Checking if customer exists...");
            if (_customerApplicationService.CustomerExist(entity.Id))
            {
                Console.WriteLine("Customer already exists");
                throw new EntityDoesExistException();
            }

            try
            {
                Console.WriteLine("Adding customer to repository...");
                Console.WriteLine("CUIT"+entity.CuilCuit);
                string createdId = await _context.AddOneAsync(entity);
                Console.WriteLine($"Customer created with ID: {createdId}");

                Console.WriteLine("Publishing CustomerCreated event...");
                CustomerCreated customerCreated = new CustomerCreated(entity.CuilCuit,entity.DocumentNumber,
                    entity.Email,entity.FirstName,entity.LastName);
                await _domainBus.Publish(customerCreated, cancellationToken);
                Console.WriteLine("Event published.");

                return createdId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during customer creation: {ex.Message}, InnerException: {ex.InnerException?.Message}");
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    } 
}
