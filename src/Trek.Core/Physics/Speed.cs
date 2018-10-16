namespace Trekish.Models.Physics
{
    public class Speed : Rate<DistanceUnits>
    {
        public Speed()
        {
        }

        public Speed(double value) : base(value)
        {
        }

        public Speed(double value, DistanceUnits units) : base(value, units)
        {
        }

        public Speed(double value, TimeUnits timeUnits) : base(value, timeUnits)
        {
        }

        public Speed(double value, DistanceUnits units, TimeUnits timeUnits) : base(value, units, timeUnits)
        {
        }

        public static explicit operator Speed(double value)
        {
            return new Speed(value);
        }

        public static explicit operator double(Speed speed)
        {
            return speed.Value;
        }

        //public static Speed operator /(Speed speed, double value)
        //{
        //    return new Speed(speed.Value / value, speed.Units);
        //}

        //public static Speed operator *(Speed speed, double value)
        //{
        //    return new Speed(speed.Value * value, speed.Units);
        //}

        //public static Speed operator -(Speed speed, double value)
        //{
        //    return new Speed(speed.Value - value, speed.Units);
        //}

        //public static Speed operator +(Speed metric, double value)
        //{
        //    return new Speed(metric.Value + value, metric.Units);
        //}
    }
}
