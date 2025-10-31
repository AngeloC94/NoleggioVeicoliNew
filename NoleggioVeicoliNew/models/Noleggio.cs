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
        public Cliente cliente;
        public Veicolo veicolo;
        public DateTime DataInizio { get; }
        public DateTime DataFine { get; }
        public double DurataGiorni;
        public Noleggio(Veicolo veicolo, Cliente cliente, double DurataGiorni,DateTime DataInizio, DateTime DataFine)
        {
            this.veicolo = veicolo;
            this.cliente = cliente;
            this.DurataGiorni = DurataGiorni;
            this.DataInizio = DataInizio;
            this.DataFine = DataFine;
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
            return veicolo.CalcolaCosto(temp);
        }

        public string descrizione() //FINITO
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return null;
            return $"inizio Noleggio a carico di {cliente.Nome}, del veicolo tg. {veicolo.Targa}, data inizio:{DataInizio}, data fine {DataFine}";
        }
    }
}
