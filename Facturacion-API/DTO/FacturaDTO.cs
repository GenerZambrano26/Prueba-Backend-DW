using System;
using System.Collections.Generic;

namespace Facturacion_API.DTO
{
    public class FacturaDTO
    {
        public string Cod { get; set; }
        public string Fecha { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public DateTime Createdday { get; set; }
        public string CodTercero { get; set; }
        public TerceroDTO Tercero { get; set; }
        public List<FacturaDetalleDTO> Detalle { get; set; }
    }

    public class FacturaDetalleDTO
    {
        public string Cod { get; set; }
        public double Precio { get; set; }
        public double Subtotal { get; set; }
        public int Cantidad { get; set; }
        public string Producto { get; set; }
        public string Codproducto { get; set; }
        public string Codfactura { get; set; }
    }
}
