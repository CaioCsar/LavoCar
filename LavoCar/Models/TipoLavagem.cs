﻿using LavoCar.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Models
{
    public class TipoLavagem
    {
        [Key]
        public long? TipoLavID { get; set; }
        public string DescTipoLav { get; set; }
        public int PrecoTipoLav { get; set; }


        public long? LavID { get; set; }
        public Lavagem Lavagem { get; set; }
    }
}
