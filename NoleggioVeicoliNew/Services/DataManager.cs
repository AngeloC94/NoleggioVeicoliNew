using NoleggioVeicoliNew.interfaces;
using NoleggioVeicoliNew.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NoleggioVeicoliNew.services
{
    public class DataManager : IDataSourceDB
    {
        public List<Cliente> ListClienti = new List<Cliente>();
        public List<Veicolo> ListVeicoli  = new List<Veicolo>();
        public List<Noleggio> ListNoleggi  = new List<Noleggio>();

        public void AddCliente(Cliente cliente) => ListClienti.Add(cliente);

        public void AddVeicolo(Veicolo veicolo) => ListVeicoli.Add(veicolo);

        public void AddNoleggio(Noleggio noleggio) => ListNoleggi.Add(new Noleggio());

        public List<Cliente> GetAllClienti() => ListClienti;

        public List<Noleggio> GetAllNoleggi() => ListNoleggi;

        public List<Veicolo> GetAllVeicoli() => ListVeicoli;

        public Cliente GetClientiById(int id) => ListClienti.Find(c => c?.id == id);

        public List<Noleggio> GetNoleggiByData(DateTime data) => ListNoleggi.Find(n => n?.DataInizio == data);

        public Noleggio GetNoleggiById(int id) => ListNoleggi.Find(n => n?.id == id);

        public Veicolo GetVeicoliById(int id) => ListVeicoli.Find(v => v?.id == id);
    }
}
