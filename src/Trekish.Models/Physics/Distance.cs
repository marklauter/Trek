namespace Trekish.Models.Physics
{
    public enum DistanceUnits
    {
        Undefined,
        Meter,
        Kilometer
    }

    public class Distance : Metric<DistanceUnits>
    {
        public Distance()
        {
        }

        public Distance(double value) : base(value)
        {
        }

        public Distance(double value, DistanceUnits units) : base(value, units)
        {
        }

        public static explicit operator Distance(double value)
        {
            return new Distance(value, DistanceUnits.Undefined);
        }

        public static explicit operator double(Distance metric)
        {
            return metric.Value;
        }
    }
}
