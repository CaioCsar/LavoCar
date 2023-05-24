using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class Carro
    {
        public long? CarroID { get; set; }

        public string Placa { get; set; }

        public int Ano { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public long? ClienteID { get; set; }
        public Cliente Cliente { get; set; }

    }
}
