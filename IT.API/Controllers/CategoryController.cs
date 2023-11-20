using IT.Application.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IT.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CategoryDto category) {
            var value = 
            await _mediator.Send(new IT.Application.Category.Commands.CreateCategory {
                Name = category.Name,
                Code = category.Code
            });
            return Ok(value);
        }
    }
}