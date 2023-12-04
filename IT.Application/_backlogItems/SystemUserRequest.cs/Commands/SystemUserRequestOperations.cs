using IT.Application.Enums;
using IT.Application.Exceptions;
using IT.Persistence;
using IT.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IT.Application.SystemUserRequest.cs.Commands {
    public class SystemUserRequestOperations : IRequest {
        public SystemUserOperationType Operation { get; set; }  
        public Guid SystemUserRequestId { get; set; }   
    }

    public class SystemUserRequestOperationsHandler : IRequestHandler<SystemUserRequestOperations> {
        private readonly DataContext _context;
        private readonly UserManager<Domain.SystemUser> _userManager;
        public SystemUserRequestOperationsHandler(DataContext context, UserManager<Domain.SystemUser> userManager) {
            _context = context;
            _userManager = userManager;
        }
        public Task Handle(SystemUserRequestOperations request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
            // var userRequest = await _context.SystemUserRequests.FindAsync(request.SystemUserRequestId);
            // if(userRequest == null) {
            //     throw new NotFoundException(userRequest);
            // }

            // switch(request.Operation) {
            //     case SystemUserOperationType.Cancel:
            //     break;
            //     case SystemUserOperationType.Approve:
            //     break;
            //     case SystemUserOperationType.Reject:
            //     break;
            //     case SystemUserOperationType.ReturnToClient:
            //     break;
            //     case SystemUserOperationType.AssignToMyself: 
            //     break;
            //     case SystemUserOperationType.Assign:
            //     break;
            //     case SystemUserOperationType.EscalateToManager:
            //     break;
            //     default:
            //         throw new ValidationException("Invalid operation.");
            // };
        }
    }
}