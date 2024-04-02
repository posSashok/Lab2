// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Salecard
{
    public int KlientId { get; set; }

    public int Bonus { get; set; }

    public virtual Klient Klient { get; set; } = null!;
}
