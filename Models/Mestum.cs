using System;
using System.Collections.Generic;

namespace kino.Models;

public partial class Mestum
{
    public long Id { get; set; }

    public string? Data { get; set; }

    public long? M1 { get; set; }

    public long? M2 { get; set; }

    public long? M3 { get; set; }

    public long? M4 { get; set; }

    public long? M5 { get; set; }

    public long? M6 { get; set; }

    public long? M7 { get; set; }

    public long? M8 { get; set; }

    public long? M9 { get; set; }

    public long? M10 { get; set; }

    public long? M11 { get; set; }

    public long? M12 { get; set; }

    public long? M13 { get; set; }

    public long? M14 { get; set; }

    public long? M15 { get; set; }

    public long? M16 { get; set; }

    public long? M17 { get; set; }

    public long? M18 { get; set; }

    public long? M19 { get; set; }

    public long? M20 { get; set; }

    public long? FkFilm { get; set; }

    public virtual Film? FkFilmNavigation { get; set; }
}
