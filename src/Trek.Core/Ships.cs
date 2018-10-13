using System;

namespace Trekish.Models
{
    public interface IShipClass : IEquipmentClass
    {
        IEngineClass ImpulseEngineClass { get; }
        IEngineClass WarpEngineClass { get; }
        Metric Mass { get; }
        EnergyWeaponClass[] WeaponSystems { get; }
    }

    public class ShipClass : IShipClass
    {
        public ShipClass(double efficiency, int techLevel, string name, Metric mass, IEngineClass impulseEngineClass, IEngineClass warpEngineClass, EnergyWeaponClass[] weaponSystems)
        {
            Efficiency = efficiency;
            TechLevel = techLevel;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Mass = mass ?? throw new ArgumentNullException(nameof(mass));
            ImpulseEngineClass = impulseEngineClass ?? throw new ArgumentNullException(nameof(impulseEngineClass));
            WarpEngineClass = warpEngineClass ?? throw new ArgumentNullException(nameof(warpEngineClass));
            WeaponSystems = weaponSystems ?? throw new ArgumentNullException(nameof(weaponSystems));
        }

        public double Efficiency { get; }
        public int TechLevel { get; }
        public string Name { get; }

        public Metric Mass { get; }
        public IEngineClass ImpulseEngineClass { get; }
        public IEngineClass WarpEngineClass { get; }
        public EnergyWeaponClass[] WeaponSystems { get; }
    }

    public class Ship
    {
        public Ship(string registration, string name, IShipClass shipClass, Engine[] impulseEngines, Engine[] warpEngines)
        {
            Registration = registration ?? throw new ArgumentNullException(nameof(registration));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Class = shipClass ?? throw new ArgumentNullException(nameof(shipClass));
            ImpulseEngines = impulseEngines ?? throw new ArgumentNullException(nameof(impulseEngines));
            WarpEngines = warpEngines ?? throw new ArgumentNullException(nameof(warpEngines));
        }

        public IShipClass Class { get; set; }

        public string Registration { get; set; }
        public string Name { get; set; }

        private Engine[] ImpulseEngines { get; }
        private Engine[] WarpEngines { get; }

        public ILocation Location { get; set; }

        //todo: add weapons

        private bool Move(ILocation location, SpeedFactor speedFactor)
        {
            // use location to get distance of move
            var distance = new Distance(1, DistanceUnits.Kilometer);
            var energy = Physics.CalculateEnergyCost(speedFactor.KilometerPerSecond, Class.Mass, distance);
            // automatically chose warp or impulse and drain fuel appropriately
            return false;
        }
    }
}
