using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Infraestructura.Servicios.Repositorios
{
    public class FacturaRepositorio : IFacturaRepositorio
    {
        private readonly ContextDB _context;

        public FacturaRepositorio(ContextDB dataContext)
        {
            _context = dataContext;
        }

        public Factura BuscarFactura(Guid FacturaId)
        {
            return _context
                .Facturas
                .Where(f => f.Cod == FacturaId)
                .Include(f => f.CodterceroNavigation)
                .Include(f => f.Detallefacturas)
                .ThenInclude(d => d.CodproductoNavigation)
                .FirstOrDefault();
        }

        public List<Factura> ListarFacturas()
        {
            return _context
                .Facturas
                .Include(f => f.CodterceroNavigation)
                .Include(f => f.Detallefacturas)
                .ThenInclude(d => d.CodproductoNavigation)
                .ToList();
        }

        public Guid RegistrarFactura(Factura factura)
        {
            factura.Cod = Guid.NewGuid();
            factura.Createdday = DateTime.Now;
            _context.Facturas.Add(factura);
            return factura.Cod;
        }

        public void ActualizarFactura(Factura factura)
        {
            var response = _context.Facturas.Where(f => f.Cod == factura.Cod).FirstOrDefault();
            if (response != null)
            {
                response.Fechahora = factura.Fechahora;
                response.Total = factura.Total;
                response.Codtercero = factura.Codtercero;
                _context.Facturas.Update(response);
            }
        }

        public void EliminarFactura(Factura factura)
        {
            _context.Facturas.Remove(factura);
        }
    }
}
