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
        void AddNoleggio(Noleggio noleggio);

        List<Veicolo> GetAllVeicoli();
        List<Cliente> GetAllClienti();
        List<Noleggio> GetAllNoleggi();

        Veicolo? GetVeicoliById(Guid id);
        Cliente? GetClientiById(Guid id);
        Noleggio? GetNoleggiById(Guid id);

        List<Noleggio> GetNoleggiByData(DateTime data);
    }
}
