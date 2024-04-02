// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int SeansId { get; set; }

    public int KlientId { get; set; }

    public int ZalId { get; set; }

    public decimal Cost { get; set; }

    public decimal Sale { get; set; }

    public decimal Finaly { get; set; }

    public virtual Klient Klient { get; set; } = null!;

    public virtual Seanse Seans { get; set; } = null!;

    public virtual Kinozal Zal { get; set; } = null!;
}
