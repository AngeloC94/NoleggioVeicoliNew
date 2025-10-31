using NoleggioVeicoliNew.interfaces;
using NoleggioVeicoliNew.models;

namespace NoleggioVeicoliNew.services
{
    public class ReportManager(IDataSourceDB db) : IReportGenerabile

    {
        List<Veicolo> veicoli = db.GetAllVeicoli();
        List<Noleggio> noleggi = db.GetAllNoleggi();

        public void GeneraReportGiornaliero()
        {
            Noleggio noleggio = db.GetNoleggioByData(DateTime.Today);

        }

        public void GeneraReportPerData(DateTime data)
        {

        }

        public void GeneraStatisticheGiornaliere()
        {

        }
    }
}
