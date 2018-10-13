using System;
using System.Collections.Generic;
using System.Text;

namespace Trekish.Models
{
    public class ShieldClass
    {
        /// <summary>
        /// different shield classes are better at absorbing damage from different weapon types
        /// </summary>
        public Dictionary<WeaponClass, Rate> DamageAbsorbtionRate { get; set; }

        /// <summary>
        /// rate of energy disipation, or demand on the ship's batteries, during engagement with a particular weapon type 
        /// </summary>
        public Dictionary<WeaponClass, Rate> EnergyDemand { get; set; }
    }
}
