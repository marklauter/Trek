using System;

namespace Trek.Models
{
    public enum ImpulseFactor
    {
        Quarter = 25,
        Half = 50,
        ThreeQuarter = 75,
        Full = 100,
        Undefined = 0
    }

    public class Velocity
    {
        public Velocity() { }

        public static Velocity FromWarpFactor(double warpFactor)
        {
            return new Velocity { WarpFactor = warpFactor };
        }

        public static Velocity FromImpluseFactor(ImpulseFactor impulseFactor)
        {
            return new Velocity { ImpulseFactor = impulseFactor };
        }

        public static Velocity FromLightFactor(double lightFactor)
        {
            return new Velocity { LightFactor = lightFactor };
        }

        public static Velocity FromKilometerPerSecond(double kmps)
        {
            return new Velocity { KilometerPerSecond = kmps };
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

        public Rate KilometerPerSecond
        {
            get => new Rate(LightFactor * 300000, TimeSpan.FromSeconds(1), "km/s");
            set
            {
                if (value < 300000000 && value >= 0)
                {
                    LightFactor = value / (300 * 1000.0);
                }
            }
        }
    }

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

        public static implicit operator Metric(double value)
        {
            return new Metric(value);
        }

        public static implicit operator double(Metric metric)
        {
            return metric.Value;
        }
    }

    public class Rate : Metric
    {
        public Rate() { }

        public Rate(double value, TimeSpan time, string units = "")
        {
            Value = value;
            Time = TimeSpan.FromTicks(time.Ticks);
            Units = units;
        }

        public TimeSpan Time { get; set; }

        public static implicit operator Rate(double value)
        {
            return new Rate(value, TimeSpan.FromSeconds(1));
        }

        public static implicit operator double(Rate rate)
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
        public static double GetEnergyCost(Velocity velocity, TimeSpan time, Metric mass, Metric distance, double efficiencyFactor)
        {
            var acceleration = velocity.KilometerPerSecond / time.Seconds;
            var force = mass * acceleration;
            var energy = force * distance;
            return energy / efficiencyFactor;
        }
    }
}
