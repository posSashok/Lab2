// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;

namespace Proekt.Models;

public partial class Film
{
    public int FilmId { get; set; }

    public string FilmName { get; set; } = null!;

    public string Long { get; set; } = null!;

    public string Janr { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Rating { get; set; } = null!;

    public string Old { get; set; } = null!;

    public virtual ICollection<Seanse> Seanses { get; set; } = new List<Seanse>();
}
