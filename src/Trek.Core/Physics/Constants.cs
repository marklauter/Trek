using System;

namespace Trekish.Models.Physics
{
    public static class Constants
    {
        /// <summary>
        /// 300,000 km/s
        /// </summary>
        public static readonly Speed SpeedOfLight = new Speed(TimeSpan.FromSeconds(1), 300000,  DistanceUnits.Kilometer);

        /// <summary>
        /// max impulse is 1/2 speed of light
        /// </summary>
        public static readonly double MaxImpulse = SpeedOfLight / 2.0;

        //public static readonly
    }
}
