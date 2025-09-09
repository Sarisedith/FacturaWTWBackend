using FacturaWTW.Application.DTOs;
using FluentValidation;
namespace FacturaWTW.Application.Validators
{
    public class ClienteCreateValidator : AbstractValidator<ClienteCreateDTO>
    {
        public ClienteCreateValidator()
        {
            RuleFor(x => x.RazonSocial).NotEmpty().MaximumLength(200);
            RuleFor(x => x.IdTipoCliente).GreaterThan(0);
            RuleFor(x => x.RFC).NotEmpty().MaximumLength(50);
        }
    }
}
