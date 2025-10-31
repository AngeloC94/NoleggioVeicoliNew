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
            List<Noleggio> noleggi = db.GetNoleggiByData(data);
            int count = noleggi.Count;
            double totale = noleggi.Sum(n => n.CalcolaTotale());
            double mediaGiorniNoleggio = noleggi.Average(n => n.DurataGiorni);
            List<Noleggio> allNoleggi = db.GetAllNoleggi();
            int vDisponibili= allNoleggi.Where(n => !n.veicolo.Noleggiato && data == DateTime.Today).ToList().Count();

            Console.WriteLine($"===Report Giornaliero===\r\nTotale incasso: {totale} €\r\nMedia Giorni di Noleggio: {mediaGiorniNoleggio}\r\nVeicoli Disponibili: {vDisponibili}");
        }

        public void GeneraStatisticheGiornaliere()
        {

        }
    }
}
