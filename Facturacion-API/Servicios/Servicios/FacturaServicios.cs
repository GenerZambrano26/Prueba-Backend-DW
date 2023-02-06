using AutoMapper;
using AutoMapper.Internal;
using Facturacion_API.DTO;
using Facturacion_API.Helpers;
using Facturacion_API.Infraestructura;
using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using Facturacion_API.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Servicios.Servicios
{
    public class FacturaServicios : IFacturaServicios
    {
        private readonly ContextDB _context;
        private readonly IFacturaRepositorio _facturaRepositorio;
        private readonly IFacturaDetalleRepositorio _facturaDetalleRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IMapper _mapper;

        public FacturaServicios(
           ContextDB dataContext,
            IFacturaRepositorio facturaRepositorio,
            IFacturaDetalleRepositorio detalleRepositorio,
            IProductoRepositorio productoRepositorio,
            IMapper mapper)
        {
            _context = dataContext;
            _facturaRepositorio = facturaRepositorio;
            _facturaDetalleRepositorio = detalleRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public ActionResult ListarFacturas()
        {
            try
            {
                var factura = _facturaRepositorio.ListarFacturas();
                return Result.Success(_mapper.Map<List<Factura>, List<FacturaDTO>>(factura));
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }
        }

        public ActionResult IngresarFactura(RequestFacturaDTO ingresarFactura)
        {
            try
            {
                Factura factura = _mapper.Map<RequestFacturaDTO, Factura>(ingresarFactura);
                Guid facturaId = _facturaRepositorio.RegistrarFactura(factura);
                foreach (var detalle in ingresarFactura.Detalle)
                {
                    Detallefactura facturaDetalle = _mapper.Map<RequestFacturaDetalleDTO, Detallefactura>(detalle);
                    facturaDetalle.Cod = Guid.NewGuid();
                    facturaDetalle.Codfactura = facturaId;
                    _facturaDetalleRepositorio.CrearFacturaDetalle(facturaDetalle);
                    _productoRepositorio.RestarCantidadProducto(facturaDetalle.Cod, detalle.Cantidad);
                }
                _context.SaveChanges();
                return Result.Success("Factura registrada");
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }
        }

        public ActionResult ActualizarFactura(RequestFacturaDTO editarFactura)
        {
            try
            {
                Guid FacturaId = Guid.Parse(editarFactura.Cod);
                var facturaGuardada = _facturaRepositorio.BuscarFactura(FacturaId);
                if (facturaGuardada != null)
                {
                    Factura facturaActualizar = _mapper.Map<RequestFacturaDTO, Factura>(editarFactura);
                    _facturaRepositorio.ActualizarFactura(facturaActualizar);

                    facturaGuardada.Detallefacturas.ForAll(detalle =>
                    {   
                        _productoRepositorio.SumarCantidadProducto(detalle.Codproducto, detalle.Cantidad);
                    });                 

                    _facturaDetalleRepositorio.EliminarFacturaDetalle(facturaGuardada.Detallefacturas);

                    foreach (var detalle in editarFactura.Detalle)
                    {
                        Detallefactura facturaDetalle = _mapper.Map<RequestFacturaDetalleDTO, Detallefactura>(detalle);
                        facturaDetalle.Cod = Guid.NewGuid();
                        facturaDetalle.Codfactura = FacturaId;
                        _facturaDetalleRepositorio.CrearFacturaDetalle(facturaDetalle);
                        _productoRepositorio.RestarCantidadProducto(facturaDetalle.Codproducto, detalle.Cantidad);
                    }
                    _context.SaveChanges();
                    return Result.Success("Factura actualizada");
                }
                return Result.NoSuccess();
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }
        }

        public ActionResult EliminarFactura(string codfactura)
        {
            try
            {
                var factura = _facturaRepositorio.BuscarFactura(Guid.Parse(codfactura));
                if (factura != null)
                {
                    foreach (var detalle in factura.Detallefacturas)
                    {
                        _productoRepositorio.SumarCantidadProducto(detalle.Codproducto, detalle.Cantidad);
                    }
                    _facturaDetalleRepositorio.EliminarFacturaDetalle(factura.Detallefacturas);
                    _facturaRepositorio.EliminarFactura(factura);
                    _context.SaveChanges();
                    return Result.Success("Factura eliminada");
                }
                return Result.NoSuccess();
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }
        }

        public ActionResult EliminarFacturaDetalleEdicion(string coddetalle)
        {
            try
            {
                var detalleFactura = _facturaDetalleRepositorio.BuscarFacturaDetalle(Guid.Parse(coddetalle));
                if (detalleFactura != null)
                {
                    _productoRepositorio.SumarCantidadProducto(detalleFactura.Codproducto, detalleFactura.Cantidad);
                    _facturaDetalleRepositorio.EliminarFacturaDetalleEdicion(detalleFactura);
                    _context.SaveChanges();
                    return Result.Success("Detalle eliminado");
                }
                return Result.NoSuccess();
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }

        }

    }
}
