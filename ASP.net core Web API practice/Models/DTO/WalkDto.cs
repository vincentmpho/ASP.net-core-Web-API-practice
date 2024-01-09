namespace Walk_and_Trails_of_SA_API.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInkm { get; set; }
        public string? WalkImaeUrl { get; set; }
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty  { get; set; }
    }
}
