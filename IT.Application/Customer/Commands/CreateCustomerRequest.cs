using AutoMapper;
using FluentValidation;
using IT.Application.Enums;
using IT.Persistence;
using MediatR;

namespace IT.Application.Customer.Commands {
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse> {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WebAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public CustomerRating Rating { get; set; }
        public DateTime SigningDate { get; set; }
        public Guid CountryId { get; set; }
    }

    public class CreateCustomerResponse {
        public Guid Id { get; set; }
    }

    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest> {
        public CreateCustomerRequestValidator() {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.Phone).MaximumLength(20);
            RuleFor(p => p.PostalCode).MaximumLength(20);
            RuleFor(p => p.WebAddress).MaximumLength(250);
            RuleFor(p => p.AddressLine1).MaximumLength(250);
            RuleFor(p => p.AddressLine2).MaximumLength(250);
            RuleFor(p => p.AddressLine3).MaximumLength(250);
            RuleFor(p => p.CountryId).NotEqual(Guid.Empty).NotNull().NotEmpty();
        }
    }

    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerRequestHandler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken) {
            var customer = _mapper.Map<Domain.Customer>(request);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateCustomerResponse{
                Id = customer.Id
            };
        }
    }
}