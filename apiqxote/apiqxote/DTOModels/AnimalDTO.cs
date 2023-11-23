﻿namespace apiqxote.DTOModels
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public double? Temperature { get; set; }

        public int? CloudCover { get; set; }

        public int? WindSpeed { get; set; }

        public string? SpeciesName { get; set; }

        public string? Coordinates { get; set; }

        public string? Abudance { get; set; }

        public string? Coverboards { get; set; }

        public string Zone { get; set; } = null!;
    }
}
