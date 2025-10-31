using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public class Furgone : Veicolo
    {
        public double CapacitaCaricoKg { get; }

        public Furgone(string targa, string modello, double tariffa, double capacitaCaricoKg) : base(targa, modello, tariffa)
        {
            this.CapacitaCaricoKg = capacitaCaricoKg;
        }

        public override double CalcolaCosto(int giorni)
        {
            double costo = giorni * TariffaGiornaliera;

            if(CapacitaCaricoKg >= 3000)
            {
                costo = costo + (TariffaGiornaliera * 0.1 * giorni);
            }
            else if(CapacitaCaricoKg > 2000)
            {
                costo = costo + (TariffaGiornaliera * 0.05 * giorni);
            }

            return costo;
        }
    }
}
