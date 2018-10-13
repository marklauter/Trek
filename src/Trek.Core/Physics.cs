using System;

namespace Trekish.Models
{
    public enum ImpulseFactor
    {
        Quarter = 25,
        Half = 50,
        ThreeQuarter = 75,
        Full = 100,
        Undefined = 0
    }

    public enum DistanceUnits
    {
        Kilometer
    }

    public class SpeedFactor
    {
        public SpeedFactor() { }

        public static SpeedFactor FromWarpFactor(double warpFactor)
        {
            return new SpeedFactor { WarpFactor = warpFactor };
        }

        public static SpeedFactor FromImpluseFactor(ImpulseFactor impulseFactor)
        {
            return new SpeedFactor { ImpulseFactor = impulseFactor };
        }

        public static SpeedFactor FromLightFactor(double lightFactor)
        {
            return new SpeedFactor { LightFactor = lightFactor };
        }

        public static SpeedFactor FromKilometerPerSecond(double kmps)
        {
            return new SpeedFactor { KilometerPerSecond = (Speed)kmps };
        }

        private double _warpFactor = 0.0;
        public double WarpFactor
        {
            get => _warpFactor;
            set
            {
                if (value < 10 && value >= 0)
                {
                    _warpFactor = value;
                    if (value > 1)
                    {
                        ImpulseFactor = ImpulseFactor.Undefined;
                    }
                    else
                    {
                        if (value >= 0 && value < 0.25)
                        {
                            ImpulseFactor = ImpulseFactor.Quarter;
                        }
                        else if (value >= 0.25 && value < 0.50)
                        {
                            ImpulseFactor = ImpulseFactor.Half;
                        }
                        else if (value >= 0.50 && value < 0.75)
                        {
                            ImpulseFactor = ImpulseFactor.ThreeQuarter;
                        }
                        else if (value >= 0.75 && value < 1.0)
                        {
                            ImpulseFactor = ImpulseFactor.Full;
                        }
                    }
                }
            }
        }

        private ImpulseFactor _impulseFactor;
        public ImpulseFactor ImpulseFactor
        {
            get => _impulseFactor;
            set
            {
                _impulseFactor = value;
                if (value != ImpulseFactor.Undefined)
                {
                    _warpFactor = (double)value / 100.0;
                }
            }
        }

        /// <summary>
        /// 1 = 1 times the speed of light and also Warp Factor 1
        /// 2 = twice the speed of light
        /// 3 = 3 times the speed of light
        /// etc.
        /// </summary>
        public double LightFactor
        {
            get => Math.Pow(_warpFactor, 1.0 / 3);
            set
            {
                if (value < 1000 && value >= 0)
                {
                    WarpFactor = Math.Pow(value, 3);
                }
            }
        }

        public Speed KilometerPerSecond
        {
            get => new Speed(TimeSpan.FromSeconds(1), LightFactor * 300000, DistanceUnits.Kilometer);
            set
            {
                if ((double)value < 300000 && (double)value >= 0)
                {
                    LightFactor = (double)value / (300000.0);
                }
            }
        }
    }

    public interface ILocation { }

    public class Metric
    {
        public Metric() { }

        public Metric(double value, string units = "")
        {
            Value = value;
            Units = units;
        }

        public double Value { get; set; }
        public string Units { get; set; }

        public static explicit operator Metric(double value)
        {
            return new Metric(value);
        }

        public static explicit operator double(Metric metric)
        {
            return metric.Value;
        }
    }

    public class Distance : Metric
    {
        public Distance()
        {
        }

        public Distance(double value, DistanceUnits units) : base(value, units.ToString())
        {
            Units = units;
        }

        public new DistanceUnits Units { get; }

        public static explicit operator Distance(double value)
        {
            return new Distance(value, DistanceUnits.Kilometer);
        }

        public static explicit operator double(Distance metric)
        {
            return metric.Value;
        }
    }

    public class Speed : Distance
    {
        public Speed()
        {
        }

        public Speed(TimeSpan time, double value, DistanceUnits units) : base(value, units)
        {
            Time = TimeSpan.FromTicks(time.Ticks);
        }

        public TimeSpan Time { get; set; }

        public static explicit operator Speed(double value)
        {
            return new Speed(TimeSpan.FromSeconds(1), value, DistanceUnits.Kilometer);
        }

        public static explicit operator double(Speed rate)
        {
            return rate.Value / rate.Time.TotalSeconds;
        }
    }

    public class Rate : Metric
    {
        public Rate() { }

        public Rate(TimeSpan time, double value, string units = "") : base(value, units)
        {
            Time = TimeSpan.FromTicks(time.Ticks);
        }

        public TimeSpan Time { get; set; }

        public static explicit operator Rate(double value)
        {
            return new Rate(TimeSpan.FromSeconds(1), value);
        }

        public static explicit operator double(Rate rate)
        {
            return rate.Value / rate.Time.TotalSeconds;
        }
    }

    public static class Physics
    {
        /// <summary>
        /// https://www.quora.com/How-do-you-convert-Newtons-to-Joules
        /// energy drain calculated by taking the mass of the ship, the warp engine efficiency and the warp factor into account
        /// </summary>
        public static double CalculateEnergyCost(Speed speed, Metric mass, Distance distance)
        {
            var time = TimeSpan.FromSeconds(speed.Value / speed.Time.TotalSeconds / distance.Value);
            var acceleration = distance.Value / time.TotalSeconds;
            var force = mass.Value * acceleration;
            var energy = force * distance.Value;
            return energy;
        }
    }
}
