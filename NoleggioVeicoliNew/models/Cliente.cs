using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public class Cliente
    {
        public int id;

        public enum Patente { 
            A,
            B,
            C
        }

        public string Nome { get;}
        public string CodiceCliente { get;}

        public Patente patente { get;}

        public Cliente(int id, string nome, string codiceCliente, Patente patente) {
            this.patente = patente;
            this.CodiceCliente = codiceCliente;
            this.Nome = nome;
            this.id = id;
        }

        public void MostraInfo()
        {
            Console.WriteLine($"Nome: {Nome} - Codice Cliente: {CodiceCliente} - Patente: {patente}");
        }

    }
}
