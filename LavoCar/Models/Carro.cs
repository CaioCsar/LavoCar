﻿using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class Carro
    {
        [Key]
        public long? CarroID { get; set; }

        [MaxLength(7)]
        public string Placa { get; set; }

        public int Ano { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public long? ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public virtual ICollection<Lavagem> Lavagens { get; set; }
        public virtual ICollection<Recibo> Recibos { get; set; }

    }
}
