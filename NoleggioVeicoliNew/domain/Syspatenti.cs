using System;
using System.Collections.Generic;

namespace NoleggioVeicoliNew.domain;

public partial class Syspatenti
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Clienti> Clientis { get; set; } = new List<Clienti>();
}
