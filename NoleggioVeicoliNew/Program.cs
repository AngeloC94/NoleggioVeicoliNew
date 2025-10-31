using NoleggioVeicoliNew.interfaces;
using NoleggioVeicoliNew.models;
using NoleggioVeicoliNew.services;

namespace NoleggioVeicoliNew
{
    public class Program
    {
        private static IDataSourceDB _db;
        private static NoleggioManager _noleggioManager;
        private static ReportManager _reportManager;
        static void Main(string[] args)
        {
            Init();

            _noleggioManager.VeicoloNoleggiato += _noleggioManager_VeicoloNoleggiato;
            _noleggioManager.VeicoloRestituito += _noleggioManager_VeicoloRestituito;

            Cliente cli1 = _db.GetAllClienti().ElementAt(3);
            Veicolo vl1 = _db.GetAllVeicoli().ElementAt(4);
            DateTime from1 = DateTime.Now;
            double dr1 = 10;
            _noleggioManager.CreaNoleggio(cli1, vl1, dr1, from1);

            Cliente cli2 = _db.GetAllClienti().ElementAt(1);
            Veicolo vl2 = _db.GetAllVeicoli().ElementAt(5);
            DateTime from2 = DateTime.Now;
            double dr2 = 5;
            _noleggioManager.CreaNoleggio(cli2, vl2, dr2, from2);

            Cliente cli3 = _db.GetAllClienti().ElementAt(7);
            Veicolo vl3 = _db.GetAllVeicoli().ElementAt(8);
            DateTime from3 = DateTime.Now;
            double dr3 = 5;
            _noleggioManager.CreaNoleggio(cli3, vl3, dr3, from3);

            Cliente cli4 = _db.GetAllClienti().ElementAt(0);
            Veicolo vl4 = _db.GetAllVeicoli().ElementAt(11);
            DateTime from4 = DateTime.Now;
            double dr4 = 7;
            _noleggioManager.CreaNoleggio(cli1, vl1, dr1, from1);

            //Cliente cli5 = _db.GetAllClienti().ElementAt(10);
            //Veicolo vl5 = _db.GetAllVeicoli().ElementAt(11);
            //DateTime from5 = DateTime.Now;
            //double dr5 = 7;
            //_noleggioManager.CreaNoleggio(cli1, vl1, dr1, from1);

            _reportManager.GeneraReportGiornaliero();
        }

        private static void _noleggioManager_VeicoloRestituito(NoleggioManager sender, Noleggio noleggioArgs)
        {
            Console.WriteLine(noleggioArgs.descrizioneFineNoleggio());
        }

        private static void _noleggioManager_VeicoloNoleggiato(NoleggioManager sender, Noleggio noleggioArgs)
        {
            Console.WriteLine(noleggioArgs.descrizioneInizioNoleggio());
        }

        private static void Init()
        {
            _db = new DataManager();
            _noleggioManager = new NoleggioManager( _db );
            _reportManager   = new ReportManager(_db);

            List<Veicolo> veicoli = new List<Veicolo>
            {
            new Auto("AB123CD", "Fiat Panda", 40, 5, false),
            new Auto("BC234DE", "Ferrari 488", 250, 2, true),
            new Auto("CD345EF", "Volkswagen Golf", 60, 5, false),
            new Auto("DE456FG", "Lamborghini Huracán", 400, 2, true),
            new Auto("EF567GH", "Ford Focus", 55, 5, false),

            new Moto("GH678IJ", "Yamaha MT-07", 35, 689),
            new Moto("HI789JK", "Harley Davidson", 80, 1746),
            new Moto("IJ890KL", "Kawasaki Ninja ZX-6R", 60, 636),
            new Moto("JK901LM", "BMW R1250GS", 90, 1254),
            new Moto("KL012MN", "Ducati Panigale V4", 120, 1103),

            new Furgone("MN123OP", "Fiat Ducato", 70, 2500),
            new Furgone("NO234PQ", "Mercedes Sprinter", 90, 3500),
            new Furgone("OP345QR", "Ford Transit", 80, 2800),
            new Furgone("PQ456RS", "Iveco Daily", 100, 3200),
            new Furgone("QR567ST", "Citroen Jumper", 75, 2000),

            new Auto("ST678UV", "Tesla Model 3", 120, 4, false),
            new Moto("UV789WX", "Suzuki Hayabusa", 110, 1340),
            new Furgone("WX890YZ", "Renault Master", 85, 2900),
            new Auto("YZ901ZA", "Alfa Romeo Giulia", 95, 4, true),
            new Moto("ZA012AB", "Honda CBR650R", 70, 649)
            };

            List<Cliente> clienti = new List<Cliente>
        {
            new Cliente("Mario Rossi", "CL001", TipoPatente.B),
            new Cliente("Luca Bianchi", "CL002", TipoPatente.A),
            new Cliente("Giulia Verdi", "CL003", TipoPatente.B),
            new Cliente("Francesca Neri", "CL004", TipoPatente.C),
            new Cliente("Paolo Ferri", "CL005", TipoPatente.B),
            new Cliente("Chiara De Luca", "CL006", TipoPatente.A),
            new Cliente("Alessandro Conti", "CL007", TipoPatente.C),
            new Cliente("Sara Romano", "CL008", TipoPatente.B),
            new Cliente("Davide Esposito", "CL009", TipoPatente.A),
            new Cliente("Elena Moretti", "CL010", TipoPatente.C)
            };

            _db.AddListClienti(clienti);
            _db.AddListVeicoli(veicoli);
        }
    }
}
