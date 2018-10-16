namespace Trekish.Models.Physics
{
    public static class Constants
    {
        /// <summary>
        /// 300,000 km/s
        /// </summary>
        public static readonly Speed SpeedOfLightKmps = new Speed(300000, DistanceUnits.Kilometer, TimeUnits.Second);

        /// <summary>
        /// max impulse is 1/2 speed of light
        /// </summary>
        public static readonly Speed MaxImpulse = new Speed(SpeedOfLightKmps.Value / 2, DistanceUnits.Kilometer, TimeUnits.Turn);
    }
}
