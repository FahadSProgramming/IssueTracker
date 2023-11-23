using FluentValidation;
using IT.API.Middleware;
using IT.Application.Core;
using IT.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// builder.Services.AddControllers(options => options.Filters.Add(new AuthorizeFilter(
//     new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()
// )));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DB Context
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Mediator
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(IT.Application.Core.MappingProfile).Assembly));
// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
// Fluent Validation
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(typeof(MappingProfile).Assembly, includeInternalTypes: true);
// DEV Cors policy
builder.Services.AddCors(options => options.AddPolicy("DevPolicy", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
// Add Identity
builder.Services.AddIdentityServices(builder.Configuration);
// builder.Services.AddAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DevPolicy");
}
// inject middleware
app.UseExceptionHandling();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using(var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    try {
        var context = services.GetRequiredService<DataContext>();
        var userContext = services.GetRequiredService<UserManager<IT.Domain.SystemUser>>();
        var roleContext = services.GetRequiredService<RoleManager<IdentityRole>>();
        await context.Database.MigrateAsync();
        await IT.Persistence.Data.CountrySeeds.Seed(context);
        await IT.Persistence.Data.IdentitySeeds.SystemUserRoleSeeds(roleContext);
        await IT.Persistence.Data.IdentitySeeds.SystemUserSeeds(userContext);
        // seed data
    } catch(Exception ex) {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migration.");
    }
}

app.Run();