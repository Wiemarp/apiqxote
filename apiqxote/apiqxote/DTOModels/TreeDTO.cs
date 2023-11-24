namespace apiqxote.DTOModels
{
    public class TreeDTO
    {
        public int TreeNr { get; set; }

        public string Zone { get; set; } = null!;

        public string? Coordinate { get; set; }

        public decimal? Height { get; set; }

        public decimal? Circumference { get; set; }

        public decimal? Volume { get; set; }

        public int BioConcentrationId { get; set; }

        public string TreeName { get; set; } = null!;
    }
}
