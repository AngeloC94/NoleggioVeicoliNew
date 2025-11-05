using System;
using System.Collections.Generic;

namespace NoleggioVeicoliNew.domain;

public partial class Auto : Veicoli
{
    public int NumeroPorte { get; set; }
    public bool IsSportiva { get; set; }
}
