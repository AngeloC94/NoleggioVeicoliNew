using System;
using System.Collections.Generic;

namespace NoleggioVeicoliNew.domain;

public partial class Noleggi
{
    public Guid Id { get; set; }

    public Guid IdCliente { get; set; }

    public Guid IdVeicolo { get; set; }

    public DateTime DataInizio { get; set; }

    public int DurataGiorni { get; set; }

    public virtual Clienti IdClienteNavigation { get; set; }

    public virtual Veicoli IdVeicoloNavigation { get; set; }
}
