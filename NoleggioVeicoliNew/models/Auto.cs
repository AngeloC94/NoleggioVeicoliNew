using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public class Auto : Veicolo
    {
        public int NumeroPorte { get; }
        public bool IsSportiva { get; }

        public Auto(string targa, string modello, double tariffa, int numeroPorte, bool IsSportiva) : base (targa,modello,tariffa)
        { 
            this.NumeroPorte = numeroPorte;
            this.IsSportiva = IsSportiva;
        }

        public override double CalcolaCosto(int giorni)
        {
            double costo = TariffaGiornaliera * giorni;

            if (IsSportiva)
            {
                costo = costo + (TariffaGiornaliera*0.1*giorni); 
            }

            return costo;
        }
    }


}
