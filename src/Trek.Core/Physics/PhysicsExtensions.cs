using System;

namespace Trekish.Models.Physics
{
    public static class PhysicsExtensions
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
