using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoleggioVeicoliNew.models;

namespace NoleggioVeicoliNew.interfaces
{
    public interface IDataSourceDB
    {
        void AddVeicolo(Veicolo veicolo);
        void AddCliente(Cliente cliente);

        List<Veicolo> GetAllVeicoli();
        List<Cliente> GetAllClienti();
        List<Noleggio> GetAllNoleggi();

        Veicolo GetVeicoliById(int id);
        Cliente GetClientiById(int id);
        Noleggio GetNoleggiById(int id);

        List<Noleggio> GetNoleggiByData(DateTime data);
    }
}
