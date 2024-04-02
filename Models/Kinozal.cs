// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Kinozal
{
    public int ZalId { get; set; }

    public int Vmestimost { get; set; }

    public int KolvoMpk { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
