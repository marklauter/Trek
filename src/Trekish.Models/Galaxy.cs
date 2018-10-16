using System.Collections.Generic;

namespace Trekish.Models
{
    public class Sector
    {
        public Sector(double size)
        {
            Size = size;
            Objects = new List<ITrekishThing>();
        }

        /// <summary>
        /// size of one side of a square in light years (2D universe to keep things simple)
        /// </summary>
        public double Size { get; }

        public List<ITrekishThing> Objects { get; }
    }

    public class Quadrant
    {
        public Quadrant(int size, double sectorSize)
        {
            Size = size;
            Sectors = new Sector[size, size];
            for(var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    Sectors[i, j] = new Sector(sectorSize);
                }
            }
        }

        public int Size { get; }

        public Sector[,] Sectors { get; } 
    }

    public class Galaxy
    {
        public Galaxy(int quadrantSize, double sectorSize)
        {
            Quadrants = new Quadrant[4];
            for(var i = 0; i < 4; ++i)
            {
                Quadrants[i] = new Quadrant(quadrantSize, sectorSize);
            }
        }

        public Quadrant[] Quadrants;
    }
}
