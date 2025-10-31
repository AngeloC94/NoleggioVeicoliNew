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
        public List<Cliente> ListClienti = [];
        public List<Veicolo> ListVeicoli  = [];
        public List<Noleggio> ListNoleggi  = [];

        public void AddCliente(Cliente cliente) => ListClienti.Add(cliente);

        public void AddVeicolo(Veicolo veicolo) => ListVeicoli.Add(veicolo);

        public void AddNoleggio(Noleggio noleggio) => ListNoleggi.Add(noleggio);

        public List<Cliente> GetAllClienti() => ListClienti;

        public List<Noleggio> GetAllNoleggi() => ListNoleggi;

        public List<Veicolo> GetAllVeicoli() => ListVeicoli;

        public Cliente? GetClientiById(Guid id) => ListClienti.Find(c => c?.Id == id);

        public List<Noleggio> GetNoleggiByData(DateTime data) => ListNoleggi.Where(n => n?.DataInizio.Date == data.Date).ToList();

        public Noleggio? GetNoleggiById(Guid id) => ListNoleggi.Find(n => n?.Id == id);

        public Veicolo? GetVeicoliById(Guid id) => ListVeicoli.Find(v => v?.Id == id);

        public void AddListVeicoli(List<Veicolo> veicoli)
        {
            ListVeicoli = veicoli;
        }

        public void AddListClienti(List<Cliente> clienti)
        {
            ListClienti = clienti;
        }

        public void UpdateNoleggio(Noleggio nl)
        {
            throw new NotImplementedException();
        }
    }
}
