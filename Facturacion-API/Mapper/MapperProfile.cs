using AutoMapper;
using Facturacion_API.DTO;
using Facturacion_API.Infraestructura;
using Facturacion_API.Infraestructura.Entidades;
using System.Linq;

namespace Facturacion_API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tercero, TerceroDTO>()
                .ForMember(dest => dest.Cod, opt => opt.MapFrom(src => src.Cod))
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => src.Nombre + " " + src.Apellido))
                  .ForMember(dest => dest.Edad,opt => opt.MapFrom(src => src.Edad ))
                   .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.Identificacion))
                     .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion));


            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.Cod, opt => opt.MapFrom(src => src.Cod))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Referencia, opt => opt.MapFrom(src => src.Referencia))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

            CreateMap<RequestFacturaDTO, Factura>()
                .ForMember(dest => dest.Cod, opt => opt.MapFrom(src => src.Cod))
                .ForMember(dest => dest.Fechahora, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.Codtercero, opt => opt.MapFrom(src => src.Codtercero));

            CreateMap<RequestFacturaDetalleDTO, Detallefactura>()
                .ForMember(dest => dest.Codfactura, opt => opt.MapFrom(src => src.Cod))
                .ForMember(dest => dest.Codproducto, opt => opt.MapFrom(src => src.Codproducto))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio));

            CreateMap<Factura, FacturaDTO>()
                .ForMember(dest => dest.Cod, opt => opt.MapFrom(src => src.Cod))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fechahora.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.Createdday, opt => opt.MapFrom(src => src.Createdday.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.Tercero, opt => opt.MapFrom(src => new TerceroDTO
                {
                    Cod = src.CodterceroNavigation.Cod.ToString(),
                    Identificacion = src.CodterceroNavigation.Identificacion,
                    NombreCompleto = src.CodterceroNavigation.Nombre + ' ' + src.CodterceroNavigation.Apellido,
                    Edad = src.CodterceroNavigation.Edad,
                    Direccion = src.CodterceroNavigation.Direccion
                }))
                .ForMember(dest => dest.Detalle, opt => opt.MapFrom(src => src.Detallefacturas.Select(x => new FacturaDetalleDTO
                {
                    Cod = x.Cod.ToString(),
                    Codproducto = x.Codproducto.ToString(),
                    Producto = x.CodproductoNavigation.Descripcion,
                    Codfactura = x.Codfactura.ToString(),
                    Precio = x.Precio,
                    Subtotal = x.Subtotal,
                    Cantidad = x.Cantidad
                })));

        }
    }
}
