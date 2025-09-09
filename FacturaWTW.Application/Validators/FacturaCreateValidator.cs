using FacturaWTW.Application.DTOs;
using FluentValidation;

namespace FacturaWTW.Application.Validators
{
    public class FacturaCreateValidator : AbstractValidator<FacturaCreateDTO>
    {
        public FacturaCreateValidator()
        {
            RuleFor(x => x.IdCliente).GreaterThan(0);
            RuleFor(x => x.NumeroFactura).GreaterThan(0);
            RuleForEach(x => x.Detalles).SetValidator(new DetalleFacturaValidator());
        }
    }

}
