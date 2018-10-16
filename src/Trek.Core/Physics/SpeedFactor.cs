using System;

namespace Trekish.Models.Physics
{
    public enum ImpulseFactor
    {
        Quarter = 125,
        Half = 250,
        ThreeQuarter = 375,
        Full = 500,
        Undefined = 0
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
            get => new Speed(Constants.SpeedOfLightKmps.Value * LightFactor, DistanceUnits.Kilometer);
            set
            {
                if ((double)value < Constants.SpeedOfLightKmps.Value && (double)value >= 0)
                {
                    LightFactor = (double)value / (Constants.SpeedOfLightKmps.Value);
                }
            }
        }
    }
}
