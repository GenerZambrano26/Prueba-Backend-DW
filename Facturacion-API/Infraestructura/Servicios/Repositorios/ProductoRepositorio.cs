
using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Infraestructura.Servicios.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ContextDB _context;

        public ProductoRepositorio(ContextDB dataContext)
        {
            _context = dataContext;
        }

        public Producto BuscarProducto(Guid cod) => _context.Productos.Where(p => p.Cod == cod).FirstOrDefault();

        public List<Producto> ListarProductos() => _context.Productos.OrderBy(p => p.Descripcion).ToList();

        public void RestarCantidadProducto(Guid ProductoId, int cantidad)
        {
            Producto producto = BuscarProducto(ProductoId);
            if (producto != null)
                producto.Stock -= cantidad;

        }

        public void SumarCantidadProducto(Guid ProductoId, int cantidad)
        {
            Producto producto = BuscarProducto(ProductoId);
            if (producto != null)
                producto.Stock += cantidad;
        }
    }
}
