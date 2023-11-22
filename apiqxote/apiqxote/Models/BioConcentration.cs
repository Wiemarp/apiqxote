using System;
using System.Collections.Generic;

namespace apiqxote.Models;

public partial class BioConcentration
{
    public int Id { get; set; }

    public string? Species { get; set; }

    public decimal? Bcf { get; set; }

    public decimal? Cf { get; set; }

    public decimal? R { get; set; }

    public decimal? Ctree { get; set; }

    public virtual ICollection<Tree> Trees { get; set; } = new List<Tree>();
}
