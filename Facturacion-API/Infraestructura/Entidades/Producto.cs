using System;
using System.Collections.Generic;

#nullable disable

namespace Facturacion_API.Infraestructura.Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            Detallefacturas = new HashSet<Detallefactura>();
        }

        public Guid Cod { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<Detallefactura> Detallefacturas { get; set; }
    }
}
