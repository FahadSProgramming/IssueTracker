using System.Data;
using AutoMapper;
using FluentValidation;
using IT.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IT.Application.Contact.Commands {
    public class CreateContactRequest : IRequest<CreateContactResponse> {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone  { get; set; }
        public string EmailAddress { get; set; }
        public string SecondaryEmailAddress { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SystemUserId { get; set; }
    }

    public class CreateContactResponse {
        public Guid Id { get; set; }
    }

    public class CreateContactRequestValidator : AbstractValidator<CreateContactRequest> {
        public CreateContactRequestValidator() {
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.MiddleName).MaximumLength(250);
            RuleFor(p => p.Designation).MaximumLength(100);
            RuleFor(p => p.PrimaryPhone).MaximumLength(20);
            RuleFor(p => p.SecondaryPhone).MaximumLength(20);
            RuleFor(p => p.EmailAddress).MaximumLength(150);
            RuleFor(p => p.SecondaryEmailAddress).MaximumLength(150);
            RuleFor(p => p.CustomerId).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(p => p.SystemUserId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }

    public class CreateContactRequestHandler : IRequestHandler<CreateContactRequest, CreateContactResponse> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CreateContactRequestHandler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateContactResponse> Handle(CreateContactRequest request, CancellationToken cancellationToken) {
            if(!await _context.Customers.AnyAsync(x => x.Id == request.CustomerId)) {
                throw new ValidationException($"A customer with ID '{request.CustomerId}' does not exist.");
            }
            var contact = _mapper.Map<Domain.Contact>(request);
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateContactResponse {
                Id = contact.Id
            };
        }
    }
}