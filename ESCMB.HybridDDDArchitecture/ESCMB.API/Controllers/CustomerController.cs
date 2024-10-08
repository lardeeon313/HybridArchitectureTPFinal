using Core.Application.ComandQueryBus.Buses;
using ESCMB.Application.UseCases.Customer.Commands.CreateCustomer;
using ESCMB.Application.UseCases.Customer.Commands.DeleteCustomer;
using ESCMB.Application.UseCases.Customer.Commands.UpdateCustomer;
using ESCMB.Application.UseCases.Customer.Queries.GetAllCustomer;
using ESCMB.Application.UseCases.Customer.Queries.GetCustomerBy;
using Microsoft.AspNetCore.Mvc;

namespace ESCMB.API.Controllers
{
    public class CustomerController(ICommandQueryBus commandQueryBus) : BaseController
    {
        private readonly ICommandQueryBus _commandQueryBus = commandQueryBus ?? throw new ArgumentNullException(nameof(commandQueryBus));

        [HttpGet("api/v1/[Controller]")]
        public async Task<IActionResult> GetAll(uint pageIndex = 1, uint pageSize = 10)
        {
            var entities = await _commandQueryBus.Send(new GetAllCustomerQuery() { PageIndex = pageIndex, PageSize = pageSize });

            return Ok(entities);
        }

        [HttpGet("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var entity = await _commandQueryBus.Send(new GetCustomerByQuery { Id = id });

            return Ok(entity);
        }

        [HttpPost("api/v1/[Controller]")]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            if (command is null) return BadRequest();

            var id = await _commandQueryBus.Send(command);

            return Created($"api/[Controller]/{id}", new { Id = id });
        }

        [HttpPut("api/v1/[Controller]")]
        public async Task<IActionResult> Update(UpdateCustomerCommand command)
        {
            if (command is null) return BadRequest();

            await _commandQueryBus.Send(command);

            return NoContent();
        }

        [HttpDelete("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            await _commandQueryBus.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}

