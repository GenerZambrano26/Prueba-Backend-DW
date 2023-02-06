using Microsoft.AspNetCore.Mvc;

namespace Facturacion_API.Servicios.Contratos
{
    public interface IClienteServicios
    {
        public ActionResult ListarClientes();
    }
}
