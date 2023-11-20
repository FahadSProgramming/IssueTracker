using AutoMapper;
using FluentValidation;
using IT.Persistence;
using MediatR;

namespace IT.Application.Category.Commands {
    public class CreateCategory : IRequest<Guid> {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class CreateCategoryValidator: AbstractValidator<CreateCategory> {
        public CreateCategoryValidator() {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.Code).NotNull().NotEmpty().MaximumLength(8);
        }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategory, Guid> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCategory request, CancellationToken cancellationToken) {
            var category = _mapper.Map<Domain.Category>(request);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}