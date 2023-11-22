using System;
using System.Collections.Generic;

namespace apiqxote.Models;

public partial class TreeName
{
    public string TreeName1 { get; set; } = null!;

    public string? CoördinateCount { get; set; }

    public virtual ICollection<Tree> Trees { get; set; } = new List<Tree>();
}
