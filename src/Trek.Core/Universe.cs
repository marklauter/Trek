namespace Trek.Models
{
    public class Sector
    {
        public Sector(double size = 300000000)
        {
            Size = size;
        }

        /// <summary>
        /// size of one side of a square in km (2D universe to keep things simple)
        /// </summary>
        public double Size { get; }
    }

    public class Quadrant
    {
        public Quadrant(double sectorSize = 300000000)
        {
            Sectors = new Sector[3, 3];
            for(var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    Sectors[i, j] = new Sector(sectorSize);
                }
            }
        }

        public Sector[,] Sectors { get; } 
    }

    public class Universe
    {
        public Universe()
        {
            Quadrants = new Quadrant[4];
            for(var i = 0; i < 4; ++i)
            {
                Quadrants[i] = new Quadrant(300000000);
            }
        }

        public Quadrant[] Quadrants;
    }
}
