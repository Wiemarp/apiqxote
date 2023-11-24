namespace apiqxote.DTOModels
{
    public class PlantDTO
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
    }
}
