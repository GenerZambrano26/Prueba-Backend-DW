using Facturacion_API.Infraestructura;
using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Infraestructura.Servicios.Repositorios
{
    public class TerceroRepositorio : ITerceroRepositorio
    {
        private readonly ContextDB _context;

        public TerceroRepositorio(ContextDB dataContext)
        {
            _context = dataContext;
        }

        public List<Tercero> ListarClientes() => _context.Terceros.OrderBy(c => c.Nombre).ToList();
    }
}
