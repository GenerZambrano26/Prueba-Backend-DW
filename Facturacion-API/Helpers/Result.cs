using Microsoft.AspNetCore.Mvc;
using System;

namespace Facturacion_API.Helpers
{
    public class Result
    {
        public static ActionResult Success(Object data)
        {
            var result = new OkObjectResult(new { status = true, data });
            return result;
        }
        public static ActionResult NoSuccess(Object mensaje = null)
        {
            if (mensaje == null)
                mensaje = "Error en la solicitud";
            var result = new BadRequestObjectResult(new { status = false, mensaje });
            return result;
        }
    }
}
