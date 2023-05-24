using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class TipoLavagem
    {
        [Key]
        public long? TipoLavID { get; set; }
        public string DescTipoLav { get; set; }

        public int PrecoTipoLav { get; set; }


    }
}
