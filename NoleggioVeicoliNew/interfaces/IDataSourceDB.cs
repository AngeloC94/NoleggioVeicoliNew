using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoleggioVeicoliNew.models;
using NoleggioVeicoliNew.services;

namespace NoleggioVeicoliNew.interfaces
{
    internal interface IDataSourceDB
    {
        void AddVeiocolo(Veicolo veicolo);
        void AddClente(Cliente cliente);

        List<Veicolo> GetAllVeicoli();
        List<Cliente> GetAllClienti();
        List<Noleggio> GetAllNoleggi();

        Veicolo GetVeicoliById(int id);
        Cliente GetClientiById(int id);
        Noleggio GetNoleggiById(int id);

        Noleggio GetNoleggioByData(DateTime data);
    }
}
