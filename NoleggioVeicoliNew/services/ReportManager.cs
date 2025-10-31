using NoleggioVeicoliNew.interfaces;

namespace NoleggioVeicoliNew.services
{
    public class ReportManager(/*IDataSourceDb db*/) : IReportGenerabile
    {
        //List<Veicolo> veicoli = db.GetVeicoli();
        //List<Noleggio> noleggi = db.GetNoleggi();

        public void GeneraReportGiornaliero()
        {
            //Noleggio noleggio = GetNoleggioByData(DateTime.Today);
        }

        public void GeneraReportPerData(DateTime data)
        {

        }

        public void GeneraStatisticheGiornaliere()
        {

        }
    }
}
