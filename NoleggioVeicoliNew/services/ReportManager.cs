using NoleggioVeicoliNew.interfaces;
using NoleggioVeicoliNew.models;

namespace NoleggioVeicoliNew.services
{
    public class ReportManager(IDataSourceDB db) : IReportGenerabile
    {
        // db.GetAllX();

        public void GeneraReportGiornaliero() => GeneraReportPerData(DateTime.Today);

        public void GeneraReportPerData(DateTime data)
        {

        }

        public void GeneraStatisticheGiornaliere()
        {

        }
    }
}
