using Core.Application.ComandQueryBus.Buses;
using ESCMB.Application.UseCases.Customer.Commands.CreateCustomer;
using ESCMB.Application.UseCases.Customer.Commands.DeleteCustomer;
using ESCMB.Application.UseCases.Customer.Commands.UpdateCustomer;
using ESCMB.Application.UseCases.Customer.Queries.GetAllCustomer;
using ESCMB.Application.UseCases.Customer.Queries.GetCustomerBy;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;

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
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Invalid ID.");

            var entity = await _commandQueryBus.Send(new GetCustomerByQuery { Id = id });

            if (entity == null)
                return NotFound($"Customer with ID {id} not found.");

            return Ok(entity);
        }

        [HttpPost("api/v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            try
            {
                if (command == null)
                {
                    return BadRequest("Command no puede ser null");
                }
                Console.WriteLine($" command: {command.CuilCuit} fisrt name {command.FirstName}");
                var id = await _commandQueryBus.Send(command);
                return Created($"api/[Controller]/{id}", new { Id = id });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                // Opcionalmente, puedes registrar la excepción completa
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return BadRequest();

            }
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

