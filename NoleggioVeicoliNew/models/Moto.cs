using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public class Moto : Veicolo
    {
        public int Cilindrata { get; }

        public Moto(string targa, string modello, double tariffa, int cilindrata) : base(targa, modello, tariffa)
        {
            this.Cilindrata = cilindrata;
        }

        public override double CalcolaCosto(int giorni)
        {
            double costo = giorni * TariffaGiornaliera;

            if (Cilindrata >= 1800)
            {
                costo = costo + (TariffaGiornaliera * 0.15 * giorni);
            }
            else if (Cilindrata >= 1200)
            {
                costo = costo + (TariffaGiornaliera * 0.1 * giorni);
            }
            else if (Cilindrata >= 600)
            {
                costo = costo + (TariffaGiornaliera * 0.05 * giorni);
            }

            return costo;
        }
    }
}
