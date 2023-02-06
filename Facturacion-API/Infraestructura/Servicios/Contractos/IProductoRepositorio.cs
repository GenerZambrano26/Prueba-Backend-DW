using Facturacion_API.Infraestructura.Entidades;
using System;
using System.Collections.Generic;

namespace Facturacion_API.Infraestructura.Servicios.Contractos
{
    public interface IProductoRepositorio
    {
        public List<Producto> ListarProductos();

        public void RestarCantidadProducto(Guid ProductoId, int cantidad);

        public void SumarCantidadProducto(Guid ProductoId, int cantidad);
    }
}
