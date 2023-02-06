using Facturacion_API.DTO;
using Facturacion_API.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServicios _IFacturaServicios;

        public FacturaController(IFacturaServicios facturaServicios)
        {
            _IFacturaServicios = facturaServicios;
        }

        // GET: api/Factura/Listar
        [HttpGet("[action]")]
        public ActionResult Listar()
        {
            return _IFacturaServicios.ListarFacturas();
        }

        // POST: api/Factura/CrearFactura
        [HttpPost("[action]")]
        public ActionResult Crear([FromBody] RequestFacturaDTO crearFactura)
        {
            return _IFacturaServicios.IngresarFactura(crearFactura);
        }

        // PUT: api/Factura/ActualizarFactura
        [HttpPut("[action]")]
        public ActionResult Actualizar([FromBody] RequestFacturaDTO actualizarFactura)
        {
            return _IFacturaServicios.ActualizarFactura(actualizarFactura);
        }

        // DETELE: api/Factura/EliminarFactura
        [HttpDelete("[action]/{codfactura}")]
        public ActionResult Eliminar(string codfactura)
        {
            return _IFacturaServicios.EliminarFactura(codfactura);

        }


        // DETELE: api/Factura/Eliminardetalle
        [HttpDelete("[action]/{coddetallefactura}")]
        public ActionResult Eliminardetalle(string coddetallefactura)
        {
            return _IFacturaServicios.EliminarFacturaDetalleEdicion(coddetallefactura);

        }



    }
}
