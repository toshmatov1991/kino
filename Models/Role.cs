using System;
using System.Collections.Generic;

namespace kino.Models;

public partial class Role
{
    public long Id { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
