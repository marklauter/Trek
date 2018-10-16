namespace Trekish.Models.Physics
{
    public interface ILocation
    {
        int QuadrantId { get; set; }
        int[,] SectorId { get; set; }
        int SectorSize { get; set; }

        Position Position { get; set; }
    }

    public class Location : ILocation
    {
        public Location() { }

        public Location(int quadrantId, int[,] sectorId, int sectorSize, Position position)
        {
            QuadrantId = quadrantId;
            SectorId = sectorId;
            Position = position;
            SectorSize = sectorSize;
        }

        public Location(Location location)
            : this(location.QuadrantId, location.SectorId, location.SectorSize, new Position(location.Position))
        {
        }

        public int QuadrantId { get; set; }
        public int[,] SectorId { get; set; }
        public int SectorSize { get; set; }

        public Position Position { get; set; } = new Position();
    }
}
