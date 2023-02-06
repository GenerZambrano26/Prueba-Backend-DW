using System;
using System.Collections.Generic;

namespace Facturacion_API.DTO
{
    public class RequestFacturaDTO
    {
        public string Cod { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Codtercero { get; set; }
        public string Subtotal { get; set; }
        public string Estado { get; set; }
        public List<RequestFacturaDetalleDTO> Detalle { get; set; }
    }

    public class RequestFacturaDetalleDTO
    {
        public string? Cod { get; set; }
        public string Codproducto { get; set; }
        public string Codfactura { get; set; }
        public double Subtotal { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
