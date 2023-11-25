using AutoMapper;
using FluentValidation;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IT.Application.Contact.Queries {
    public class GetAllContacts : IRequest<List<ContactDto>> {
        public Guid CustomerId { get; set; }
    }

    public class GetAllContactsValidator : AbstractValidator<GetAllContacts> {
        public GetAllContactsValidator() {
            RuleFor(p => p.CustomerId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class GetAllContactsHandler : IRequestHandler<GetAllContacts, List<ContactDto>> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetAllContactsHandler(DataContext context, IMapper mapper) {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ContactDto>> Handle(GetAllContacts request, CancellationToken cancellationToken) {
            var contacts = await _context.Contacts
                                 .Where(x => x.CustomerId == request.CustomerId)
                                 .ToListAsync();
            if(contacts == null || (contacts?.Count ?? 0) <= 0) {
                throw new NotFoundException($"No contacts found associated to Customer with ID '{request.CustomerId}'.");
            }
            return _mapper.Map<List<ContactDto>>(contacts);
        }
    }
}