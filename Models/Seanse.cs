// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Seanse
{
    public int SeansId { get; set; }

    public int FilmId { get; set; }

    public DateTime Nachalo { get; set; }

    public int OstMest { get; set; }

    public string? Ps { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
