using Facturacion_API.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;



namespace Facturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {
        private readonly IClienteServicios _iClienteServices;

        public TerceroController(IClienteServicios clienteServices)
        {
            _iClienteServices = clienteServices;
        }

        // GET: api/Tercero/Listar
        [HttpGet("[action]")]
        public ActionResult Listar() => _iClienteServices.ListarClientes();

    }
}
