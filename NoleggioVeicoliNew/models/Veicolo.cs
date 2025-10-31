using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public abstract class Veicolo
    {
        public string Targa { get; private set; }
        public string Modello { get; private set; }
        public double TariffaGiornaliera { get; private set; }

        public Veicolo(string targa, string modello, double tariffa)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.TariffaGiornaliera = tariffa;
        }

        public abstract double CalcolaCosto(int giorni);

        public string MostraDettagli()
        {
            return $"[{GetType().Name}] {Modello} - Targa: {Targa}, Tariffa: {TariffaGiornaliera:C} al giorno";
        }


    }
}

