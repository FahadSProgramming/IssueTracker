using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IT.Persistence.Data;
using IT.Application.Customer.Commands;
using MediatR;
using IT.Application.Customer.Queries;

namespace IT.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = $"{SystemUserRoles.Role_SysAdmin},{SystemUserRoles.Role_SysUser_Manager},{SystemUserRoles.Role_SysUser},{SystemUserRoles.Role_Client_Manager}")]
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
        [Authorize(Roles = $"{SystemUserRoles.Role_SysAdmin},{SystemUserRoles.Role_SysUser_Manager}")]
        public async Task<IActionResult> GetAllCustomers(GetAllCustomers request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id) {
            return Ok(await _mediator.Send(new GetCustomerDetail {
                Id = id
            }));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpPatch("ActivateAccount/{id}")]
        [Authorize(Roles = SystemUserRoles.Role_SysAdmin)]
        public async Task<IActionResult> ActivateAccount(Guid id, bool activate = true) {
            await _mediator.Send(new ActivateCustomerRequest {
                Id = id,
                Activate = activate
            });
            return Ok();
        }
    }
}