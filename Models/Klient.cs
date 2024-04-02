// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Klient
{
    public int KlientId { get; set; }

    public string Familia { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string Bday { get; set; }

    public string Kontact { get; set; } = null!;

    public virtual Salecard? Salecard { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
