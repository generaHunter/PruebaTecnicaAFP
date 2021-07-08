using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public int TipoTramiteId { get; set; }

        public TipoTramite TipoTramite { get; set; }

        public double Total { get; set; }
    }
}
