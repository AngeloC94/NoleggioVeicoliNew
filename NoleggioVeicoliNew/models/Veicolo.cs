using NoleggioVeicoliNew.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public abstract class Veicolo : INoleggiabile
    {
        public Guid Id { get; }
        public string Targa { get; }
        public string Modello { get; }
        public double TariffaGiornaliera { get; }
        public bool Noleggiato { get; private set; }

        public Veicolo(string targa, string modello, double tariffa)
        {
            this.Targa = targa;
            this.Modello = modello;
            this.TariffaGiornaliera = tariffa;
            this.Noleggiato = false;
            this.Id = new Guid();
        }

        public abstract double CalcolaCosto(int giorni);

        public string MostraDettagli()
        {
            return $"[{GetType().Name}] {Modello} - Targa: {Targa}, Tariffa: {TariffaGiornaliera:C} al giorno";
        }

        public bool Noleggia()
        {
            bool successo = Noleggiato!;

            if (Noleggiato!) { 
                Noleggiato = true;
            }

            return successo;
        }

        public bool Restituisci()
        {
            bool successo = Noleggiato;
            if (Noleggiato)
            {
                Noleggiato = false;
            }

            return successo;
        }
    }
}

