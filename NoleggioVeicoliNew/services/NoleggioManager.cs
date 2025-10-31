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
    public delegate void OnVeicoloNoleggiatoEventHandler(NoleggioManager sender,Noleggio noleggioArgs);
    public delegate void OnVeicoloRestituitoEventHandler(NoleggioManager sender, Noleggio noleggioArgs);
    public class NoleggioManager
    {
        private IDataSourceDB _idb;

        public NoleggioManager(IDataSourceDB idb)
        {
            _idb = idb;
        }

        public event OnVeicoloNoleggiatoEventHandler VeicoloNoleggiato;
        public event OnVeicoloRestituitoEventHandler VeicoloRestituito;

        public void OnVeicoloNoleggiato(Noleggio noleggio)
        {// tramite noleggio, accedo al veicolo e al metodo noleggia.

            
            if (VeicoloNoleggiato != null)
            {
                VeicoloNoleggiato(this, noleggio);
            }
        }
        public void OnVeicoloRestituito(Noleggio noleggio)
        {
            if (VeicoloRestituito != null)
            {
                VeicoloRestituito(this, noleggio);
            }
        }



        public void CreaNoleggio(Cliente cl , Veicolo veicolo, double durata,DateTime inizio)
        {

            Noleggio nl = new Noleggio(veicolo, cl, durata, inizio, inizio.AddDays(durata));          
            try
            {
                var result = veicolo.Noleggia();
                _idb.AddNoleggio(nl);
                OnVeicoloNoleggiato(nl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }

        public bool TerminaNoleggio(Noleggio nl)
        {
            bool terminaNoleggioIsOK = nl.Veicolo.Restituisci();
            if (terminaNoleggioIsOK)
            {
                _idb.UpdateNoleggio(nl);
                OnVeicoloNoleggiato(nl);
            }
            return terminaNoleggioIsOK;          
        }

    }
}
