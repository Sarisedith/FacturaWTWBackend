using FacturaWTW.Application.DTOs;
using FluentValidation;

namespace FacturaWTW.Application.Validators
{
    public class DetalleFacturaValidator : AbstractValidator<DetalleFacturaDTO>
    {
        public DetalleFacturaValidator()
        {
            RuleFor(x => x.IdProducto).GreaterThan(0);
            RuleFor(x => x.CantidadDeProducto).GreaterThan(0);
            RuleFor(x => x.PrecioUnitarioProducto).GreaterThan(0);
        }
    }
}
