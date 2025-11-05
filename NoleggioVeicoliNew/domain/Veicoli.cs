using System;
using System.Collections.Generic;

namespace NoleggioVeicoliNew.domain;

public partial class Veicoli
{
    public Guid Id { get; set; }

    public string Targa { get; set; } = null!;

    public string Modello { get; set; } = null!;

    public double TariffaGiornaliera { get; set; }

    public bool Noleggiato { get; set; }

    public virtual ICollection<Noleggi> Noleggis { get; set; } = new List<Noleggi>();
}
