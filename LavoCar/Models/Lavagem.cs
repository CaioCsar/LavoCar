using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class Lavagem
    {
        public long? LavId { get; set; }
        public DateTime DataLav { get; set; }

        public int Valor { get; set; }
    }
}
