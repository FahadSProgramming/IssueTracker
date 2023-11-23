using AutoMapper;
using FluentValidation;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Category.Commands {
    public class UpdateCategoryRequest : IRequest<UpdateCategoryResponse> {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    
    public class UpdateCategoryResponse {
        public Guid Id { get; set; }
    }

    public class UpdateCategoryRequestValidtor : AbstractValidator<UpdateCategoryRequest> {
        public UpdateCategoryRequestValidtor() {
            RuleFor(p => p.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.Code).NotNull().NotEmpty().MaximumLength(8);
        }
    }

    public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UpdateCategoryRequestHandler(DataContext context, IMapper mapper) {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken) {
            var category = await _context.Categories.FindAsync(request.Id);
            if(category == null) {
                throw new NotFoundException(category);
            }
            _mapper.Map(request, category);
            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateCategoryResponse {
                Id = category.Id
            };
        }
    }
}