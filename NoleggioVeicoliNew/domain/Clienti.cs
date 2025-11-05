using System;
using System.Collections.Generic;

namespace NoleggioVeicoliNew.domain;

public partial class Clienti
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? CodiceCliente { get; set; }

    public int TipoPatente { get; set; }

    public virtual ICollection<Noleggi> Noleggis { get; set; } = new List<Noleggi>();

    public virtual Syspatenti TipoPatenteNavigation { get; set; } = null!;
}
