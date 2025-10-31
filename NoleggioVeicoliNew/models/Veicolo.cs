using NoleggioVeicoliNew.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.models
{
    public delegate void VeicoloNoleggiatoEventHandler(NoleggioManager sen, Veicolo veicolo);
    public class Veicolo
    {

        public event VeicoloNoleggiatoEventHandler NoleggioIniziato;

        public Veicolo(NoleggioManager nl)
        {
            nl.Subscribe(this);
        }

        public void Noleggiato()
        {
            Console.WriteLine("sucaaaaaaa");
        }

        private void OnVeicoloNoleggiato()
        {

        }
    }
}
