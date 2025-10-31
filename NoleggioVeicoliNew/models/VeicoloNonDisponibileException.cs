using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    internal class VeicoloNonDisponibileException : Exception
    {
        public VeicoloNonDisponibileException(string message = "Veicolo noleggiato")
            : base(message)
        {
            
        }
        public VeicoloNonDisponibileException()
            :base("Veicolo già noleggiato")
        {
            
        }
        public override string Message => "Veicolo già noleggiato";
    }
}
