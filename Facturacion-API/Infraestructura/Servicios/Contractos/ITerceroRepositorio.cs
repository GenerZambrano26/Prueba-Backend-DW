using Facturacion_API.Infraestructura.Entidades;
using System.Collections.Generic;

namespace Facturacion_API.Infraestructura.Servicios.Contractos
{
    public interface ITerceroRepositorio
    {
        public List<Tercero> ListarClientes();
    }
}
