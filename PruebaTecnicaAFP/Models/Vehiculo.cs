using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public int TipoTramiteId { get; set; }
        public TipoTramite TipoTramite { get; set; }

        [Required]
        public double PrecioTramite { get; set; }

        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
