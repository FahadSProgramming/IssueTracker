using AutoMapper;
using FluentValidation;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Contact.Queries {
    public class GetContactDetail : IRequest <ContactDto> {
        public Guid Id { get; set; }
    }

    public class GetContactDetailValidator : AbstractValidator<GetContactDetail> {
        public GetContactDetailValidator() {
            RuleFor(p => p.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class GetContactDetailsHandler : IRequestHandler<GetContactDetail, ContactDto> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetContactDetailsHandler(DataContext context, IMapper mapper) {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ContactDto> Handle(GetContactDetail request, CancellationToken cancellationToken) {
            var contact = await _context.Contacts.FindAsync(request.Id);
            if(contact == null) {
                throw new NotFoundException(contact);
            }
            return _mapper.Map<ContactDto>(contact);
        }
    }
}