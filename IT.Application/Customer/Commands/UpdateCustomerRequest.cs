using AutoMapper;
using FluentValidation;
using IT.Application.Enums;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Customer.Commands {
    public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse> {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string WebAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public CustomerRating Rating { get; set; }
    }

    public class UpdateCustomerResponse {
        public Guid Id { get; set; }
    }

    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest> {
        public UpdateCustomerRequestValidator() {
            RuleFor(p => p.Phone).MaximumLength(20);
            RuleFor(p => p.PostalCode).MaximumLength(20);
            RuleFor(p => p.WebAddress).MaximumLength(250);
            RuleFor(p => p.AddressLine1).MaximumLength(250);
            RuleFor(p => p.AddressLine2).MaximumLength(250);
            RuleFor(p => p.AddressLine3).MaximumLength(250);
            RuleFor(p => p.Id).NotEqual(Guid.Empty).NotNull().NotEmpty();
        }
    }

    public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UpdateCustomerRequestHandler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken) {
            var existingCustomer = await _context.Customers.FindAsync(request.Id);
            if(existingCustomer == null) {
                throw new NotFoundException(existingCustomer);
            }
            _mapper.Map(request, existingCustomer);
            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateCustomerResponse {
                Id = existingCustomer.Id
            };
        }
    }
}