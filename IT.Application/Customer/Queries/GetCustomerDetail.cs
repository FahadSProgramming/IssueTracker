using AutoMapper;
using FluentValidation;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Customer.Queries {
    public class GetCustomerDetail : IRequest<CustomerDto> {
        public Guid Id { get; set; }
    }

    public class GetCustomerDetailValidator : AbstractValidator<GetCustomerDetail> {
        public GetCustomerDetailValidator() {
            RuleFor(p => p.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class GetCustomerDetailHandler : IRequestHandler<GetCustomerDetail, CustomerDto> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetCustomerDetailHandler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerDetail request, CancellationToken cancellationToken) {
            var customer = await _context.Customers.FindAsync(request.Id);
            if(customer == null) {
                throw new NotFoundException(customer);
            }
            var response = _mapper.Map<CustomerDto>(customer);
            return response;
        }
    }
}