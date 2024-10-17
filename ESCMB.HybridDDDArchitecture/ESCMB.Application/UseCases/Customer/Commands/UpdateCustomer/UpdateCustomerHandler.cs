using Core.Application.ComandQueryBus.Buses;
using Core.Application.ComandQueryBus.Commands;
using Core.Application.Mapping;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.DomainEvents.Customer;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using ESCMB.Domain.Entities;
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
    internal sealed class UpdateDummyEntityHandler(ICommandQueryBus domainBus, ICustomerRepository customerRepository) : IRequestCommandHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly ICustomerRepository _context = customerRepository  ?? throw new ArgumentNullException(nameof(customerRepository));

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer entity = await _context.FindOneAsync(request.Id) ?? throw new EntityDoesNotExistException();

            
           
            if (request.CuilCuit!=null) { entity.CuilCuit = request.CuilCuit; }
            if (request.DocumentNumber!=null) { entity.DocumentNumber = request.DocumentNumber; }
            if (request.Email!=null) { entity.Email = request.Email; }
            if (request.FirstName!=null) { entity.FirstName = request.FirstName; }
            if (request.LastName!=null) { entity.LastName = request.LastName; }
            try
            {       
                _context.Update(entity);
                await _domainBus.Publish(entity.To<CustomerUpdated>(), cancellationToken);

                return await Unit.Task;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar: {ex.Message}");
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException); ;
            }
        }
    }
}
