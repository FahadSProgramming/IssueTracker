using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IT.Application.Core {
    

    public static class IdentityServiceExtensions {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config) {
            services.AddIdentityCore<IT.Domain.SystemUser>()
                    .AddRoles<IdentityRole>()
                    .AddTokenProvider<DataProtectorTokenProvider<IT.Domain.SystemUser>>("IssueTracker")
                    .AddEntityFrameworkStores<IT.Persistence.DataContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            services.AddScoped<IdentityTokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            return services;
        }
    }
}