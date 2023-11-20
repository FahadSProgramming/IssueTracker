using FluentValidation;
using MediatR;

namespace IT.Application.Core
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators) {
            _validators = validators;
        }

        // public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {

        //     var context = new ValidationContext<TRequest>(request);

        //     var failures = _validators
        //     .Select(v => v.Validate(context))
        //     .SelectMany(res => res.Errors)
        //     .Where(x => x != null)
        //     .ToList();

        //     if(failures.Count > 0) {
        //         throw new Exceptions.ValidationException(failures);
        //     }

        //     return next();
        // }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
            if(!_validators.Any()) {
                return await next();
            }
            var failures = _validators
                           .Select(validator => validator.Validate(request))
                           .SelectMany(validationResult => validationResult.Errors)
                           .Where(validationFailures => validationFailures is not null)
                           .ToList();
            if(failures.Any()) {
                throw new Exceptions.ValidationException(failures);
            }
            return await next();
        }
    }
}