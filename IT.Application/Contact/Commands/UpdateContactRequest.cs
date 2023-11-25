using AutoMapper;
using FluentValidation;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Contact.Commands {
    public class UpdateContactRequest : IRequest<UpdateContactResponse> {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone  { get; set; }
        public string EmailAddress { get; set; }
        public string SecondaryEmailAddress { get; set; }
    }

    public class UpdateContactResponse {
        public Guid Id { get; set; }
    }

    public class UpdateContactRequestValidator : AbstractValidator<UpdateContactRequest> {
        public UpdateContactRequestValidator() {
            RuleFor(p => p.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(p => p.MiddleName).MaximumLength(250);
            RuleFor(p => p.Designation).MaximumLength(100);
            RuleFor(p => p.PrimaryPhone).MaximumLength(20);
            RuleFor(p => p.SecondaryPhone).MaximumLength(20);
            RuleFor(p => p.EmailAddress).MaximumLength(150);
            RuleFor(p => p.SecondaryEmailAddress).MaximumLength(150);
        }
    }

    public class UpdateContactRequestHandler : IRequestHandler<UpdateContactRequest, UpdateContactResponse> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UpdateContactRequestHandler(DataContext context, IMapper mapper) {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UpdateContactResponse> Handle(UpdateContactRequest request, CancellationToken cancellationToken) {
            var contact = await _context.Contacts.FindAsync(request.Id);
            if(contact == null) {
                throw new NotFoundException(contact);
            }
            _mapper.Map(request, contact);
            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateContactResponse {
                Id = contact.Id
            };
        }
    }
}