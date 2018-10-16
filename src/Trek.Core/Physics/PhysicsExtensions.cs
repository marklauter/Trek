using System;

namespace Trekish.Models.Physics
{
    public static class PhysicsExtensions
    {
        public static TimeSpan Duration(this Distance distance, Speed speed)
        {
            switch (speed.TimeUnits)
            {
                case TimeUnits.Millisecond:
                    return TimeSpan.FromMilliseconds(speed.Value / distance.Value);
                case TimeUnits.Turn:
                case TimeUnits.Second:
                    return TimeSpan.FromSeconds(speed.Value / distance.Value);
                case TimeUnits.Minute:
                    return TimeSpan.FromMinutes(speed.Value / distance.Value);
                case TimeUnits.Hour:
                    return TimeSpan.FromHours(speed.Value / distance.Value);
                case TimeUnits.Day:
                    return TimeSpan.FromDays(speed.Value / distance.Value);
                case TimeUnits.Undefined:
                default:
                    throw new NotSupportedException();
            }
        }

        public static double Acceleration(this Distance distance, Speed speed, TimeSpan time)
        {
            switch (speed.TimeUnits)
            {
                case TimeUnits.Millisecond:
                    return distance.Value / time.TotalMilliseconds;
                case TimeUnits.Turn:
                case TimeUnits.Second:
                    return distance.Value / time.TotalSeconds;
                case TimeUnits.Minute:
                    return distance.Value / time.TotalMinutes;
                case TimeUnits.Hour:
                    return distance.Value / time.TotalHours;
                case TimeUnits.Day:
                    return distance.Value / time.TotalDays;
                case TimeUnits.Undefined:
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// https://www.quora.com/How-do-you-convert-Newtons-to-Joules
        /// energy drain calculated by taking the mass of the ship, the warp engine efficiency and the warp factor into account
        /// </summary>
        public static double CalculateEnergyCost(Speed speed, Mass mass, Distance distance)
        {
            var time = distance.Duration(speed);
            var acceleration = distance.Acceleration(speed, time);
            var force = mass.Value * acceleration;
            var energy = force * distance.Value;
            return energy;
        }
    }
}
