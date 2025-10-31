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
            return TariffaGiornaliera * giorni;
        }
    }
}
