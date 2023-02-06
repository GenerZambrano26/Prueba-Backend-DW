using AutoMapper;
using Facturacion_API.DTO;
using Facturacion_API.Helpers;
using Facturacion_API.Infraestructura.Entidades;
using Facturacion_API.Infraestructura.Servicios.Contractos;
using Facturacion_API.Servicios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion_API.Servicios.Servicios
{
    public class ClienteServicios : IClienteServicios
    {
        private readonly IMapper _mapper;

        private readonly ITerceroRepositorio _clienteRepositorio;

        public ClienteServicios(ITerceroRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public ActionResult ListarClientes()
        {
            try
            {
                List<Tercero> response = _clienteRepositorio.ListarClientes();
                if (response.Any())
                    return Result.Success(_mapper.Map<List<Tercero>, List<TerceroDTO>>(response));

                return Result.NoSuccess();
            }
            catch (Exception ex)
            {
                return Result.NoSuccess(ex.Message);
            }
        }
    }
}
