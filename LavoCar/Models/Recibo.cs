using LavoCar.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Models
{
    public class Recibo
    {
        [Key]
        public long? ReciboID { get; set; }

        public long? ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public long? CarroID { get; set; }
        public Carro Carro { get; set; }

        public long? LavID { get; set; }
        public Lavagem Lavagem { get; set; }

        public long? TipoLavID { get; set; }
        public TipoLavagem TipoLavagem { get; set; }
    }
}
