using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Models
{
    public class TipoTramite
    {
        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}

