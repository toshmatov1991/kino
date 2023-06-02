using System;
using System.Collections.Generic;

namespace kino.Models;

public partial class User
{
    public long Id { get; set; }

    public string? Fio { get; set; }

    public string? Login { get; set; }

    public string? Pass { get; set; }

    public long? FkRole { get; set; }

    public virtual ICollection<Bilet> Bilets { get; set; } = new List<Bilet>();

    public virtual Role? FkRoleNavigation { get; set; }
}
