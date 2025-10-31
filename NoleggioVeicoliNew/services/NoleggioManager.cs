using NoleggioVeicoliNew.interfaces;
using NoleggioVeicoliNew.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.services
{
    public delegate void OnVeicoloNoleggiatoEventHandler(NoleggioManager sen,Noleggio noleggio);
    public delegate void OnVeicoloRestituitoEventHandler(NoleggioManager sendr, Noleggio Noleggioargs);
    public class NoleggioManager
    {

    }
}
