using IT.Application.Category;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT.API.Controllers.Admin {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = IT.Persistence.Data.SystemUserRoles.Role_SysAdmin)]
    public class CategoryController : ControllerBase {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CategoryDto category) {
            var value = 
            await _mediator.Send(new IT.Application.Category.Commands.CreateCategoryRequest {
                Name = category.Name,
                Code = category.Code
            });
            return Ok(value);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory(IT.Application.Category.Commands.UpdateCategoryRequest request) {
            var value = await _mediator.Send(request);
            return Ok(value);
        }
    }
}