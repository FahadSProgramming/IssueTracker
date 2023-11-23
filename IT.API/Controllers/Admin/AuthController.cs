using IT.Application.SystemUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT.API.Controllers.Admin {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles =  IT.Persistence.Data.SystemUserRoles.Role_SysAdmin)]
    public class AuthController : ControllerBase {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserRequest request) {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationRequest request) {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}