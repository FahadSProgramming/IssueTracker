using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IT.Application.SystemUser {
    public class RegistrationRequest : IRequest <RegistrationResponse> {
        public string DisplayName { get; set; }
        public string Username { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
    }

    public class RegistrationResponse {
        public Guid Id { get; set; }
    }

    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest> {
        public RegistrationRequestValidator() {
            RuleFor(p => p.DisplayName).NotNull().NotEmpty();
            RuleFor(p => p.Email).NotNull().NotEmpty();
            RuleFor(p => p.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }

    public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, RegistrationResponse> {

        private readonly UserManager<Domain.SystemUser> _userManager;
        private readonly IMapper _mapper;
        public RegistrationRequestHandler(UserManager<Domain.SystemUser> userManager, IMapper mapper) {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken) {
            var existingUser = await _userManager.FindByEmailAsync(request.Email.ToLower());
            if(existingUser != null) {
                throw new ValidationException("An account with this email address already exists.");
            }
            var systemUser = _mapper.Map<Domain.SystemUser>(request);
            systemUser.Email = systemUser.Email.ToLower();
            systemUser.UserName = systemUser.Email;
            await _userManager.CreateAsync(systemUser);
            if(request.Roles?.Count > 0) {
                await _userManager.AddToRolesAsync(systemUser, request.Roles);
            }

            return new RegistrationResponse {
                Id = Guid.Parse(systemUser.Id)
            };
        }
    }
}