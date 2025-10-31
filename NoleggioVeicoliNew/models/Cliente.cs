using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public enum TipoPatente
    {
        A,
        B,
        C
    }

    public class Cliente
    {
        public Guid Id;
        public string Nome { get;}
        public string CodiceCliente { get;}

        public TipoPatente Patente { get;}

        public Cliente(string nome, string codiceCliente, TipoPatente patente) {
            this.Patente = patente;
            this.CodiceCliente = codiceCliente;
            this.Nome = nome;
            this.Id = Guid.NewGuid();
        }

        public void MostraInfo()
        {
            Console.WriteLine($"Nome: {Nome} - Codice Cliente: {CodiceCliente} - Patente: {Patente}");
        }

    }
}
