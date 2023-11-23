using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IT.Persistence.Data;
using IT.Application.Customer.Commands;
using MediatR;
using IT.Application.Customer.Queries;

namespace IT.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = $"{SystemUserRoles.Role_SysAdmin},{SystemUserRoles.Role_SysUser_Manager},{SystemUserRoles.Role_SysUser}")]
    public class CustomerController : ControllerBase {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpPost("Create")]
        [Authorize(Roles = SystemUserRoles.Role_SysAdmin)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomers(GetAllCustomers request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id) {
            return Ok(await _mediator.Send(new GetCustomerDetail {
                Id = id
            }));
        }
    }
}