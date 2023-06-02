using System;
using System.Collections.Generic;

namespace kino.Models;

public partial class Bilet
{
    public long Id { get; set; }

    public string? SumB { get; set; }

    public long? NumM { get; set; }

    public string? Data { get; set; }

    public long? FkFilm { get; set; }

    public long? FkUser { get; set; }

    public virtual Film? FkFilmNavigation { get; set; }

    public virtual User? FkUserNavigation { get; set; }
}
