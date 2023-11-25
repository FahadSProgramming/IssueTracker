using FluentValidation;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Customer.Commands
{
    public class ActivateCustomerRequest : IRequest {
        public Guid Id { get; set; }        
        public bool Activate { get; set; }
    }

    public class ActivateCustomerRequestValidator : AbstractValidator<ActivateCustomerRequest> {
        public ActivateCustomerRequestValidator() {
            RuleFor(p => p.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class ActivateCustomerRequestHandler : IRequestHandler<ActivateCustomerRequest> {
        private readonly DataContext _context;
        public ActivateCustomerRequestHandler(DataContext context) {
            _context = context;
        }
        public async Task Handle(ActivateCustomerRequest request, CancellationToken cancellationToken) {
            var customer = await _context.Customers.FindAsync(request.Id);
            
            if(customer == null) {
                throw new NotFoundException(customer);
            }
            customer.IsActive = request.Activate;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}