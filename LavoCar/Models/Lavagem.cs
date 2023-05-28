using LavoCar.Models;
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
        
        [Display(Name = "Data")]
        public DateTime DataLav { get; set; }

        [Display(Name = "Valor")]
        public int ValorLav { get; set; }
        
        public virtual ICollection<TipoLavagem> TipoLavagens { get; set; }

        public long? CarroID { get; set; }
        public Carro Carro { get; set; }
    }
}
