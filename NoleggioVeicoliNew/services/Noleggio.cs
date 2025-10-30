using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.services
{
    public class Noleggio
    {
        // public Cliente cliente;
        // public Veicolo veicolo;
        public DateTime DataInizio { get; }
        public int DurataGiorni; //cambiare in timespan
        
        public double CalcolaTotale()
        {
            return 0;
            //return DurataGiorni*veicolo.Prezzo
        }
    }
}
