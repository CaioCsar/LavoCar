using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class Lavagem
    {
        [Key]
        public long? LavID { get; set; }
        public DateTime DataLav { get; set; }

        public int ValorLav { get; set; }

        public virtual ICollection<TipoLavagem> TipoLavagens { get; set; }
    }
}
