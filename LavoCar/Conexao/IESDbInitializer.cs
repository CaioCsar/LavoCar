using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Conexao
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();
            if (context.Clientes.Any())
            {
                return;
            }
            var cliente = new Cliente[]
            {
                new Cliente {NomeCliente="Gilberto Nunes", EndCliente="Rua B numero 22", FoneCliente="79998122323"},
                new Cliente {NomeCliente="Samuca Endinho", EndCliente="Rua Salgueiro numero 44", FoneCliente="79922122323"}
            };
            foreach (Cliente d in cliente)
            {
                context.Clientes.Add(d);
            }
            context.SaveChanges();
        }

    }
}
