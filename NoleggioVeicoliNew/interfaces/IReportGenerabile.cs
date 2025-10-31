namespace NoleggioVeicoliNew.interfaces
{
    public interface IReportGenerabile
    {
        public void GeneraReportGiornaliero();
        public void GeneraReportPerData(DateTime data);
        public void GeneraStatisticheGiornaliere();
    }
}
