using Facturacion_API.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;



namespace Facturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicios _iProductoServices;

        public ProductoController(IProductoServicios productoServices)
        {
            _iProductoServices = productoServices;
        }

        // GET: api/Producto/Listar
        [HttpGet("[action]")]
        public ActionResult Listar()
        {
            return _iProductoServices.ListarProductos();
        }
    }

}