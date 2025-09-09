using AutoMapper;
using FacturaWTW.Application.DTOs;
using FacturaWTW.Domain.Entities;

namespace FacturaWTW.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Tipo Cliente
            CreateMap<CatTipoCliente, TipoClienteCrearDTO>().ReverseMap();
            CreateMap<CatTipoCliente, TipoClienteActualizarDTO>().ReverseMap();
            CreateMap<TipoClienteDTO, CatTipoCliente>().ReverseMap();

            // Cliente
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();

            // Factura
            CreateMap<Factura, FacturaDTO>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaDTO>().ReverseMap();
            CreateMap<FacturaCreateDTO, Factura>();

            // Producto
            CreateMap<CatProducto, ProductoDTO>().ReverseMap();
            CreateMap<ProductoCrearDTO, CatProducto>()
                .ForMember(d => d.Id, o => o.Ignore());
            CreateMap<ProductoActualizarDTO, CatProducto>();

        }
    }
}
