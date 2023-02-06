using System;
using System.Collections.Generic;

#nullable disable

namespace Facturacion_API.Infraestructura.Entidades
{
    public partial class Factura
    {
        public Factura()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public Guid Cod { get; set; }
        public DateTime Fechahora { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public Guid Codtercero { get; set; }
        public DateTime Createdday { get; set; }
        public int Estado { get; set; }

        public virtual Tercero CodterceroNavigation { get; set; }
        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
