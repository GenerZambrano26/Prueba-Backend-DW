using AutoMapper;
using Facturacion_API.DTO;
using Facturacion_API.Helpers;
using Facturacion_API.Infraestructura;
using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using Facturacion_API.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Servicios.Servicios
{
    public class ProductoServicios : IProductoServicios
    {
        private readonly IMapper _mapper;

        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoServicios(IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public ActionResult ListarProductos()
        {
            try
            {
                var response = _productoRepositorio.ListarProductos();
                if (response.Any())
                    return Result.Success(_mapper.Map<List<Producto>, List<ProductoDTO>>(response));

                return Result.NoSuccess();
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }
        }
    }
}
