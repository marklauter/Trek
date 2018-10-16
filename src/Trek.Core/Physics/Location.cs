namespace Trekish.Models.Physics
{
    public interface ILocation
    {
        int QuadrantId { get; set; }
        int[,] SectorId { get; set; }

        Position Position { get; set; }
    }

    public class Location : ILocation
    {
        public Location() { }

        public Location(int quadrantId, int[,] sectorId, Position position)
        {
            QuadrantId = quadrantId;
            SectorId = sectorId;
            Position = position;
        }

        public Location(Location location)
            : this(location.QuadrantId, location.SectorId, new Position(location.Position))
        {
        }

        public int QuadrantId { get; set; }
        public int[,] SectorId { get; set; }

        public Position Position { get; set; }
    }
}
