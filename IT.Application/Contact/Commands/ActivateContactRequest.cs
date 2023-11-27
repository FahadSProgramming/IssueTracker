using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;

namespace IT.Application.Contact.Commands {
    public class ActivateContactRequest : IRequest {
        public Guid ContactId { get; set; }        
        public bool Activate { get; set; }
    }

    public class ActivateContactRequestHandler : IRequestHandler<ActivateContactRequest> {
        private readonly DataContext _context;
        public ActivateContactRequestHandler(DataContext context) {
            _context = context;
        }
        public async Task Handle(ActivateContactRequest request, CancellationToken cancellationToken) {
            var existingContact = await _context.Contacts.FindAsync(request.ContactId);
            if(existingContact == null) {
                throw new NotFoundException(existingContact);
            }

            if(existingContact.IsActive == request.Activate) {
                return;
            }

            existingContact.IsActive = request.Activate;
            await _context.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}