<img width="1355" height="988" alt="Diagramma" src="https://github.com/user-attachments/assets/e17cc0e6-2b9c-4e41-85ec-3c15b6a999a8" />
Il progetto deve consentire di:
registrare veicoli disponibili al noleggio;
simulare clienti che noleggiano e restituiscono veicoli;
calcolare il costo del noleggio in base al tipo di veicolo e ai giorni;
generare un report finale con le statistiche (totale incassi, veicoli noleggiati, ecc.).

Specifiche generali
Classi di base
1. Veicolo (classe astratta)
Proprietà: Targa, Modello, TariffaGiornaliera
Metodo astratto: CalcolaCosto(int giorni)
Metodo concreto: MostraDettagli()
2. Classi derivate:
Auto
Proprietà: NumeroPorte
Implementa CalcolaCosto con eventuale sovrapprezzo se sportiva
Moto
Proprietà: Cilindrata
Furgone
Proprietà: CapacitaCaricoKg
3. Cliente
Proprietà: Nome, Patente, CodiceCliente
Metodo: MostraInfo()
4. Noleggio
Proprietà: Cliente, Veicolo, DataInizio, DurataGiorni
Metodo: CalcolaTotale()
Metodo: Descrizione()

 Interfacce e funzionalità richieste
1. Interfacce
INoleggiabile con metodi Noleggia() e Restituisci()
IReportGenerabile con metodo GeneraReport()
2. Eventi
Evento OnVeicoloNoleggiato nel gestore principale (NoleggioManager)
Evento OnVeicoloRestituito → notifica su console
3. LINQ
Filtrare veicoli disponibili/noleggiati
Calcolare statistiche (es. “media durata noleggi”, “totale incassi per tipo di veicolo”)
4. Polimorfismo
La lista dei veicoli deve essere di tipo List<Veicolo> ma contenere Auto, Moto, Furgone.
5. Dependency Injection
L’interfaccia IReportGenerabile deve essere iniettata in NoleggioManager, così i gruppi possono sviluppare report diversi in modo indipendente.








Struttura generale del progetto
/NoleggioVeicoli
 ├── Program.cs
 ├── Models/
 │    ├── Veicolo.cs (astratta)
 │    ├── Auto.cs
 │    ├── Moto.cs
 │    ├── Furgone.cs
 │    └── Cliente.cs
 ├── Interfaces/
 │    ├── INoleggiabile.cs
 │    └── IReportGenerabile.cs
 ├── Services/
 │    ├── Noleggio.cs
 │    ├── NoleggioManager.cs
 │    └── ReportManager.cs

🧠 Divisione in 3 gruppi
Gruppo
Area di responsabilità
Obiettivi concreti
Gruppo 1
Modello e gerarchia di classi (OOP)
Implementare Veicolo e le derivate, più la classe Cliente. Gestire costruttori, override, e metodi astratti.
Gruppo 2
Logica di business e gestione noleggi
Creare Noleggio, NoleggioManager, e gestire l’elenco di veicoli, gli eventi OnVeicoloNoleggiato / OnVeicoloRestituito. Implementare LINQ per ricerca e filtri.
Gruppo 3
Report e statistiche
Implementare IReportGenerabile e fornire un report stampato in console o file (ad esempio: totale incassi, numero veicoli per tipo, durata media).

🧾 Esempio di output atteso
=== Sistema Noleggio Veicoli ===

[Evento] Veicolo AB123CD noleggiato da Mario Rossi per 3 giorni.
[Evento] Veicolo AB123CD restituito. Totale: 210,00 €

=== Report giornaliero ===
Totale veicoli noleggiati: 5
Totale incasso: 1250,00 €
Media giorni di noleggio: 2.8
Veicoli disponibili: 7
Veicoli più richiesti: Auto (3)
