using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LavoCar.Controllers;

namespace LavoCar.Controllers
{
    public class TipoLavagem
    {
        [Key]
        public long? TipoLavID { get; set; }

        
        [Display(Name = "Tipo de Lavagem")]
        public string DescTipoLav { get; set; }

        
        [Display(Name = "Preço da Lavagem")]
        public int PrecoTipoLav { get; set; }


    }
}
