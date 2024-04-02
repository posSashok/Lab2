// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Personal
{
    public int NomPers { get; set; }

    public string Familia { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public string KontNom { get; set; } = null!;

    public string Doljnost { get; set; } = null!;
}
