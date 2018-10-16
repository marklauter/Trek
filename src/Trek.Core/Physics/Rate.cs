using System;

namespace Trekish.Models.Physics
{
    public enum TimeUnits
    {
        Undefined,
        Millisecond,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Turn
    }

    public interface IRate<T> : IMetric<T>
        where T : Enum
    {
        TimeUnits TimeUnits { get; set; }
    }

    public class Rate<T> : Metric<T>, IRate<T>
        where T : Enum
    {
        public Rate()
        {
        }

        public Rate(double value) : base(value)
        {
        }

        public Rate(double value, T units) : base(value, units)
        {
        }

        public Rate(double value, TimeUnits timeUnits) : base(value)
        {
            TimeUnits = timeUnits;
        }

        public Rate(double value, T units, TimeUnits timeUnits) : base(value, units)
        {
            TimeUnits = timeUnits;
        }

        public TimeUnits TimeUnits { get; set; } = TimeUnits.Turn;

        public static explicit operator Rate<T>(double value)
        {
            return new Rate<T>(value);
        }

        public static explicit operator double(Rate<T> rate)
        {
            return rate.Value;
        }
    }
}
