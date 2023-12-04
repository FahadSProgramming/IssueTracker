using IT.Application.Enums;
using IT.Application.SystemUserRequest.Commands;
using IT.Application.SystemUserRequest.cs.Commands;
using IT.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT.API.Controllers {
    // [ApiController]
    // [Route("api/[controller]")]
    [Authorize(Roles = $"{SystemUserRoles.Role_SysAdmin},{SystemUserRoles.Role_SysUser_Manager},{SystemUserRoles.Role_SysUser},{SystemUserRoles.Role_Client_Manager}")]
    public class SysUserRequestController : ControllerBase {
        private readonly IMediator _mediator;
        public SysUserRequestController(IMediator mediator) {
            _mediator = mediator;
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserRequest(CreateSystemUserRequest request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("Update/{id}/{operation}")]
        public async Task<IActionResult> UpdateUserRequest(Guid id, SystemUserOperationType operation) {
            await _mediator.Send(new SystemUserRequestOperations{
                Operation = operation,
                SystemUserRequestId = id
            });
            return Ok();
        }   
    }
}