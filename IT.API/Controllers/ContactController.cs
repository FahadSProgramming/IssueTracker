using IT.Application.Contact.Commands;
using IT.Application.Contact.Queries;
using IT.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = $"{SystemUserRoles.Role_SysAdmin},{SystemUserRoles.Role_SysUser_Manager},{SystemUserRoles.Role_SysUser},{SystemUserRoles.Role_Client_Manager}")]
    public class ContactController : ControllerBase {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateContact(CreateContactRequest request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateContact(UpdateContactRequest request) {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetContacts/{customerId}")]
        public async Task<IActionResult> GetContactsByCustomer(Guid customerId) {
            return Ok(await _mediator.Send(new GetAllContacts {
                CustomerId = customerId
            }));
        }

        [HttpGet("GetContactById/{id}")]
        public async Task<IActionResult> GetContactById(Guid id) {
            return Ok(await _mediator.Send(new GetContactDetail {
                Id = id
            }));
        }

        [HttpPatch("Activate/{id}/{activate}")]
        [Authorize(Roles = $"{SystemUserRoles.Role_SysAdmin},{SystemUserRoles.Role_SysUser_Manager}")]
        public async Task<IActionResult> ActivateContact(Guid id, bool activate) {
            await _mediator.Send(new ActivateContactRequest {
                ContactId = id,
                Activate = activate
            });
            return Ok();
        }
    }
}