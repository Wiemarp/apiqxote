using System;
using System.Collections.Generic;

namespace apiqxote.Models;

public partial class Plant
{
    public int PlantId { get; set; }

    public string? PlotNr { get; set; }

    public string? Coordinate { get; set; }

    public string? Species { get; set; }

    public string? Cover { get; set; }

    public string? Temperature { get; set; }

    public float? Humidity { get; set; }

    public DateTime? Date { get; set; }

    public string Zone { get; set; } = null!;

    public virtual Zone ZoneNavigation { get; set; } = null!;
}
