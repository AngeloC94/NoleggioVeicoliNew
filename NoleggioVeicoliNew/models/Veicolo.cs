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
            this.Id = Guid.NewGuid();
        }

        public abstract double CalcolaCosto(int giorni);

        public string MostraDettagli()
        {
            return $"[{GetType().Name}] {Modello} - Targa: {Targa}, Tariffa: {TariffaGiornaliera:C} al giorno";
        }

        public bool Noleggia()
        {
            if (Noleggiato)
            {
                throw new VeicoloNonDisponibileException("veicolo "+ this.Targa + " già noleggiato");
            }
            Noleggiato = true;
            return true;
        }
        public bool Restituisci()
        {
            if (!Noleggiato) return false;
            Noleggiato = false;

            return true;
        }
    }
}

