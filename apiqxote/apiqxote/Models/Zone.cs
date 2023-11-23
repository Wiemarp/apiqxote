using System;
using System.Collections.Generic;
using apiqxote.Models;

namespace apiqxote.Models;

public partial class Zone
{
    public string Zone1 { get; set; } = null!;

    public int? Area { get; set; }

    public string? Classification { get; set; }

    public int? Plots { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();

    public virtual ICollection<Tree> Trees { get; set; } = new List<Tree>();
}
