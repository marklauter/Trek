using System;
using System.Collections.Generic;

namespace Trek.Models
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

    public enum EngineTypes
    {
        Impulse = 0,
        Warp = 1
    }

    public class Engine
    {
        /// <summary>
        /// 1.0 would mean zero energy drain when engine is engaged
        /// </summary>
        public double Efficiency { get; set; }
        public EngineTypes Type { get; set; }
    }

    public class ShipClass
    {
        public string Name { get; set; }

        public double MaxEnergy { get; set; }
        public Velocity MaxWarp { get; set; }
        public Velocity MaxImpluse { get; set; }
        public double Mass { get; set; }

        public EnergyWeaponClass[] WeaponArray { get; }

        public Dictionary<EngineTypes, Engine> Engines { get; }
    }

    public class Ship
    {
        public ShipClass Class { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
    }
}
