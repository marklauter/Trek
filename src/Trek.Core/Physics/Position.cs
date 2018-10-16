using System;

namespace Trekish.Models.Physics
{
    public interface IPosition
    {
        double X { get; }
        double Y { get; }
        Distance Distance(Position other);
    }

    /// <summary>
    /// location within a sector
    /// X,Y is like lat,lon and measured in 100,000km blocks
    /// so 0.5,0.5 is 50,000km, 50,000km from 0,0
    /// if speed of light, C, is 300,000km/s 
    ///   and max impulse is 1/2 C, 
    ///   and a movement trun == 1 second, 
    ///   then a ship can travel 3 full sector blocks per turn
    /// </summary>
    public class Position : IPosition
    {
        public Position() { }
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Position(Position other) : this(other.X, other.Y) { }

        public double X { get; }
        public double Y { get; }

        public Distance Distance(Position other)
        {
            var deltaX = X - other.X;
            var deltaY = Y - other.Y;
            var sum = Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2);
            return new Distance(Math.Sqrt(sum), DistanceUnits.Kilometer);
        }
    }
}
