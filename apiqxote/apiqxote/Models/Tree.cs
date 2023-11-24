using System;
using System.Collections.Generic;
using apiqxote.Models;

namespace apiqxote.Models;

public partial class Tree
{
    public int TreeNr { get; set; }

    public string Zone { get; set; } = null!;

    public string? Coordinate { get; set; }

    public decimal? Height { get; set; }

    public decimal? Circumference { get; set; }

    public decimal? Volume { get; set; }

    public int BioConcentrationId { get; set; }

    public string TreeName { get; set; } = null!;

    public virtual BioConcentration BioConcentration { get; set; } = null!;

    public virtual TreeName TreeNameNavigation { get; set; } = null!;

    public virtual Zone ZoneNavigation { get; set; } = null!;
}
