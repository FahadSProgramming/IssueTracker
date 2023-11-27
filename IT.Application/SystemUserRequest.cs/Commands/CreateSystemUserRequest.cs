using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IT.Application.SystemUserRequest.Commands {
    public class CreateSystemUserRequest : IRequest <CreateSystemUserResponse> {
        public Guid RequestorId { get; set; }   
        public Guid CustomerId { get; set; }
        public Guid SystemUserId { get; set; }
        public bool IsManager { get; set; }
    }

    public class CreateSystemUserResponse {
        public Guid Id { get; set; }
    }

    public class CreateSystemUserRequestHandler : IRequestHandler<CreateSystemUserRequest, CreateSystemUserResponse> {
        private readonly DataContext _context;
        public CreateSystemUserRequestHandler(DataContext context) {
            _context = context;
        }
        public async Task<CreateSystemUserResponse> Handle(CreateSystemUserRequest request, CancellationToken cancellationToken) {
            var existingContact = await _context.Contacts.FindAsync(request.RequestorId);
            if(existingContact == null || !(existingContact?.IsActive ?? false)) {
                throw new NotFoundException(existingContact);
            }

            if(existingContact.CustomerId != request.CustomerId) {
                throw new ValidationException($"The user requestor with Id '{existingContact.Id} does not belong to the provided customer with Id '{request.CustomerId}'.");
            }

            var existingRequest = await _context.SystemUserRequests.AnyAsync(x => x.RequestorId == request.RequestorId);
            if(existingRequest) {
                throw new ValidationException($"A system user request has already been submitted for the requestor with Id $'{request.RequestorId}'.");
            }

            var userRequest = new Domain.SystemUserRequest {
                Id = Guid.NewGuid(),
                DisplayName = existingContact.FirstName,
                RequestorId = existingContact.Id,
                CustomerId = existingContact.CustomerId,
                Email = existingContact.EmailAddress,
                Position = existingContact.Designation,
                IsActive = false,
                IsManager = request.IsManager,
                SystemUserId = existingContact.SystemUserId,
                PhoneNumber = existingContact.PrimaryPhone,
                Status = Enums.UserRequestStatus.New.GetHashCode()
            };

            await _context.SystemUserRequests.AddAsync(userRequest);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateSystemUserResponse {
                Id = userRequest.Id
            };
        }
    }
}