using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse>:
        IPipelineBehavior<TRequest,TResponse> where TRequest:IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this._validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validatonResults = await Task.WhenAll(_validators.Select(v=>v.ValidateAsync(context,cancellationToken)));
                var failures = validatonResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count!=0)
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
