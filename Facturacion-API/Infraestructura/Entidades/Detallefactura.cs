using System;
using System.Collections.Generic;

#nullable disable

namespace Facturacion_API.Infraestructura.Entidades
{
    public partial class Detallefactura
    {
        public Guid Cod { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public Guid Codfactura { get; set; }
        public Guid Codproducto { get; set; }

        public virtual Factura CodfacturaNavigation { get; set; }
        public virtual Producto CodproductoNavigation { get; set; }
    }
}
