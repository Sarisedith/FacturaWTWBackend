using FacturaWTW.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaWTW.Application.Validators
{
    public class ProductoActualizarValidator : AbstractValidator<ProductoActualizarDTO>
    {
        public ProductoActualizarValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El Id del producto debe ser mayor a 0.");

            RuleFor(x => x.NombreProducto)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.PrecioUnitario)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");

            RuleFor(x => x.Ext)
                .MaximumLength(5).WithMessage("La extensión de la imagen no puede superar 5 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Ext));
        }
    }
}
