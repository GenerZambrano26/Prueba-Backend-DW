using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Infraestructura.Servicios.Repositorios
{
    public class DetalleFacturaRepositorio : IFacturaDetalleRepositorio
    {

        private readonly ContextDB _context;

        public DetalleFacturaRepositorio(ContextDB dataContext)
        {
            _context = dataContext;
        }

        public Detallefactura BuscarFacturaDetalle(Guid DetalleId)
        {
            return _context.Detallefacturas.Where(p => p.Cod == DetalleId).FirstOrDefault();
        }

        public void CrearFacturaDetalle(Detallefactura detalleFactura)
        {
            _context.Detallefacturas.Add(detalleFactura);
        }

        public void ActualizarFacturaDetalle(Detallefactura detalleFactura)
        {
            _context.Detallefacturas.Update(detalleFactura);
        }

        public void EliminarFacturaDetalle(ICollection<Detallefactura> listDetalleFactura)
        {
            _context.Detallefacturas.RemoveRange(listDetalleFactura);
        }

        public void EliminarFacturaDetalleEdicion(Detallefactura facturaDetalle)
        {
            _context.Detallefacturas.Remove(facturaDetalle);

        }

    }
}
