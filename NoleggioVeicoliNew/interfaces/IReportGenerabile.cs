
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.interfaces
{
    internal interface IReportGenerabile
    {
        public void GeneraReportGiornaliero();
        public void GeneraReportPerData(DateTime data);
        public void GeneraStatisticheGiornaliere();
    }
}
