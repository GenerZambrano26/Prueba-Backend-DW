using Facturacion_API.DTO;
using Facturacion_API.Infraestructura.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion_API.Servicios.Contratos
{
    public interface IFacturaServicios
    {
        public ActionResult ListarFacturas();

        public ActionResult IngresarFactura(RequestFacturaDTO IngresarFactura);

        public ActionResult ActualizarFactura(RequestFacturaDTO EditarFactura);

        public ActionResult EliminarFactura(string FacturaId);

        public ActionResult EliminarFacturaDetalleEdicion(string facturaDetalle);
    }
}
