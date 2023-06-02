using System;
using System.Collections.Generic;

namespace kino.Models;

public partial class Film
{
    public long Id { get; set; }

    public string? NameFilm { get; set; }

    public string? Zhanr { get; set; }

    public byte[]? Photo { get; set; }

    public double? Sale { get; set; }

    public long? ColMest { get; set; }

    public string? Data { get; set; }

    public virtual ICollection<Archiv> Archivs { get; set; } = new List<Archiv>();

    public virtual ICollection<Bilet> Bilets { get; set; } = new List<Bilet>();

    public virtual ICollection<Mestum> Mesta { get; set; } = new List<Mestum>();
}
