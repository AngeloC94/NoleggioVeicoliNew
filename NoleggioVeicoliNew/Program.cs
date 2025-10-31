using NoleggioVeicoliNew.models;
using NoleggioVeicoliNew.services;

namespace NoleggioVeicoliNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NoleggioManager nm = new NoleggioManager();
            Veicolo v1 = new Veicolo(nm);
        }
    }
}
