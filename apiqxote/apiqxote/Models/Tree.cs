using System;
using System.Collections.Generic;

namespace apiqxote.Models;

public partial class Tree
{
    public int TreeNr { get; set; }

    public string? Coördinate { get; set; }

    public decimal? Height { get; set; }

    public decimal? Circumference { get; set; }

    public decimal? Volume { get; set; }

    public int BioConcentrationId { get; set; }

    public string TreeName { get; set; } = null!;

    public string Zone { get; set; } = null!;

    public virtual BioConcentration BioConcentration { get; set; } = null!;

    public virtual TreeName TreeNameNavigation { get; set; } = null!;

    public virtual Zone ZoneNavigation { get; set; } = null!;
}
