using System;
using System.Collections.Generic;

namespace kino.Models;

public partial class Archiv
{
    public long Id { get; set; }

    public long? KolBilet { get; set; }

    public double? Summ { get; set; }

    public long? FkFilm { get; set; }

    public virtual Film? FkFilmNavigation { get; set; }
}
