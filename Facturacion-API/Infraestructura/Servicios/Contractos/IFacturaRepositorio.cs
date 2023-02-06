using Facturacion_API.Infraestructura.Entidades;
using System;
using System.Collections.Generic;

namespace Facturacion_API.Infraestructura.Servicios.Contractos
{
    public interface IFacturaRepositorio
    {
        public Factura BuscarFactura(Guid FacturaId);

        public List<Factura> ListarFacturas();

        public Guid RegistrarFactura(Factura factura);

        public void ActualizarFactura(Factura factura);

        public void EliminarFactura(Factura factura);
    }
}
