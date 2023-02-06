using Facturacion_API.Infraestructura.Entidades;
using System;
using System.Collections.Generic;


namespace Facturacion_API.Infraestructura.Servicios.Contractos
{
    public interface IFacturaDetalleRepositorio
    {
        public Detallefactura BuscarFacturaDetalle(Guid FacturaDetalleId);

        public void CrearFacturaDetalle(Detallefactura facturaDetalle);

        public void ActualizarFacturaDetalle(Detallefactura facturaDetalle);

        public void EliminarFacturaDetalle(ICollection<Detallefactura> listDetalleFactura);

        public void EliminarFacturaDetalleEdicion(Detallefactura facturaDetalle);


    }
}
