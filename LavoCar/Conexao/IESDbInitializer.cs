using LavoCar.Controllers;
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

            //CLIENTE
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

            //CARRO
            if (context.Carros.Any())
            {
                return;
            }
            var carro = new Carro[]
            {
                new Carro {Placa="AUC1234", Ano=2001, Marca="Fiat", Modelo="Uno Miller", ClienteID=1},
                new Carro {Placa="TOC1223", Ano=2011, Marca="Honda", Modelo="Nissan Fronties", ClienteID=2}
            };
            foreach (Carro d in carro)
            {
                context.Carros.Add(d);
            }
            context.SaveChanges();


            //TIPO DE LAVAGEM
            if (context.TipoLavagens.Any()) {
                return;
            }
            var tipolavagem = new TipoLavagem[]
            {

                new TipoLavagem {DescTipoLav= "Lavagem Simples", PrecoTipoLav=20},
                new TipoLavagem {DescTipoLav= "Lavagem Simples com Cera", PrecoTipoLav=50}
            };
            foreach (TipoLavagem d in tipolavagem) {
                context.TipoLavagens.Add(d);
            }

            context.SaveChanges();

            //LAVAGEM
            if (context.Lavagens.Any())
            {
                return;
            }
            var lavagem = new Lavagem[]
            {
              
            };
            foreach (Cliente d in cliente)
            {
                context.Clientes.Add(d);
            }
            context.SaveChanges();


        }

    }
}
