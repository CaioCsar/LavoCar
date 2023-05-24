using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class TipoLavagem
    {
        public long? TipoLavID { get; set; }
        public string DescTipoLav { get; set; }

        public int PrecoTipoLav { get; set; }
    }
}
