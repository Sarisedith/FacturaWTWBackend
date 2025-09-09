using FacturaWTW.Application.DTOs;
using FluentValidation;
namespace FacturaWTW.Application.Validators
{
    public class ClienteUpdateValidator : AbstractValidator<ClienteUpdateDTO>
    {
        public ClienteUpdateValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.RazonSocial).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IdTipoCliente).GreaterThan(0);
            RuleFor(x => x.RFC).NotEmpty().MaximumLength(50);
        }
    }
}
