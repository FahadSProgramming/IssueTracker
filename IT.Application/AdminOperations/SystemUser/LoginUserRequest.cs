using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using IT.Application.Core;
using IT.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IT.Application.SystemUser {
    public class LoginUserRequest : IRequest<LoginUserResponse> {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserResponse {
        public Guid Id { get; set; }
        public string Token { get; set; }
    }

    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest> {
        public LoginUserRequestValidator() {
            RuleFor(p => p.Username).NotNull().NotEmpty();
            RuleFor(p => p.Password).NotNull().NotEmpty();
        }
    }

    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse> {
        private readonly UserManager<IT.Domain.SystemUser> _userManager;
        private readonly IdentityTokenService _tokenService;
        public LoginUserRequestHandler(IdentityTokenService tokenService, UserManager<IT.Domain.SystemUser> userManager) {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByEmailAsync(request.Username);
            if(user == null) {
                throw new UnauthorizedAccessException();
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
            if(!passwordCheck) {
                throw new UnauthorizedAccessException(); 
            }
            var roles = await _userManager.GetRolesAsync(user);
            return new LoginUserResponse {
                Id = Guid.Parse(user.Id),
                Token = _tokenService.CreateToken(user, roles)
            };
        }
    }

}