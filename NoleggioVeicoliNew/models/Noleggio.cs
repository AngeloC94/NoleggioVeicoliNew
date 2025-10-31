using NoleggioVeicoliNew.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public class Noleggio 
    {
        public Guid Id;
        public Cliente Cliente;
        public Veicolo Veicolo;
        public DateTime DataInizio { get; }
        public DateTime DataFine { get; }
        public double DurataGiorni;
        public Noleggio(Veicolo veicolo, Cliente cliente, double DurataGiorni,DateTime DataInizio, DateTime DataFine)
        {
            this.Veicolo = veicolo;
            this.Cliente = cliente;
            this.DurataGiorni = DurataGiorni;
            this.DataInizio = DataInizio;
            this.DataFine = DataFine;
            this.Id = new Guid();
        }
        public double CalcolaTotale() //FINITO
        {
            int temp = (int)DurataGiorni;
            TimeSpan Mora =DataInizio.AddDays(DurataGiorni).Subtract(DataFine);
            if (Mora.TotalDays>0)
            {
                DurataGiorni += Mora.TotalDays;
                Math.Ceiling(DurataGiorni);
                temp = (int)DurataGiorni;
            }
            return Veicolo.CalcolaCosto(temp);
        }

        public string descrizione() //FINITO
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return null;
            return $"inizio Noleggio a carico di {Cliente.Nome}, del veicolo tg. {Veicolo.Targa}, data inizio:{DataInizio}, data fine {DataFine}";
        }
    }
}
