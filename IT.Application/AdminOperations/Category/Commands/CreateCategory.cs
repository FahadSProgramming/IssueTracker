using AutoMapper;
using FluentValidation;
using IT.Persistence;
using MediatR;

namespace IT.Application.Category.Commands {
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse> {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class CreateCategoryResponse {
        public Guid Id { get; set; }
    }

    public class CreateCategoryValidator: AbstractValidator<CreateCategoryRequest> {
        public CreateCategoryValidator() {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.Code).NotNull().NotEmpty().MaximumLength(8);
        }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken) {
            var category = _mapper.Map<Domain.Category>(request);
            category.Code =  category.Code.ToUpperInvariant();
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateCategoryResponse {
                Id = category.Id
            };
        }
    }
}