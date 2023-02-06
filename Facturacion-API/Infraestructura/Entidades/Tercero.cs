using System;
using System.Collections.Generic;

#nullable disable

namespace Facturacion_API.Infraestructura.Entidades
{
    public partial class Tercero
    {
        public Tercero()
        {
            Facturas = new HashSet<Factura>();
        }

        public Guid Cod { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
