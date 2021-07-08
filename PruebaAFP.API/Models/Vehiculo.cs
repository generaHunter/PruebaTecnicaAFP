using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAFP.API.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        public string Marca { get; set; }

        public int TipoTramiteId { get; set; }
        public TipoTramite TipoTramite { get; set; }

        public double PrecioTramite { get; set; }

        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
