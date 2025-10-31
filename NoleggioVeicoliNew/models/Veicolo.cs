using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public abstract class Veicolo
    {
        public string Targa { get; }
        public string Modello { get; }
        public double TariffaGiornaliera { get; }
        public int id { get; }
        public bool Noleggiato { get; }

        public Veicolo(string targa, string modello, double tariffa, int id)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.TariffaGiornaliera = tariffa;
            this.Noleggiato = false;
            this.id = id;
        }

        public abstract double CalcolaCosto(int giorni);

        public string MostraDettagli()
        {
            return $"[{GetType().Name}] {Modello} - Targa: {Targa}, Tariffa: {TariffaGiornaliera:C} al giorno";
        }


    }
}

