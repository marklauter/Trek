using System;
using Trekish.Models.Physics;

namespace Trekish.Models.Ships
{
    public interface IShipClass : IEquipmentClass
    {
        IEngineClass ImpulseEngineClass { get; set; }
        IEngineClass WarpEngineClass { get; set; }
        Mass Mass { get; set; }
        //EnergyWeaponClass[] WeaponSystems { get; set; }
    }

    public class ShipClass : EquipmentClass, IShipClass
    {
        public ShipClass()
        {
        }

        public ShipClass(int techLevel, double efficiency, string name, string description) 
            : base(techLevel, efficiency, name, description)
        {
        }

        //public ShipClass(int techLevel, double efficiency, string name, string description,
        //    Mass mass, IEngineClass impulseEngineClass, IEngineClass warpEngineClass, EnergyWeaponClass[] weaponSystems)
        //    : base(techLevel, efficiency, name, description)
        public ShipClass(int techLevel, double efficiency, string name, string description,
            Mass mass, IEngineClass impulseEngineClass, IEngineClass warpEngineClass)
            : base(techLevel, efficiency, name, description)
        {
            Mass = mass ?? throw new ArgumentNullException(nameof(mass));
            ImpulseEngineClass = impulseEngineClass ?? throw new ArgumentNullException(nameof(impulseEngineClass));
            WarpEngineClass = warpEngineClass ?? throw new ArgumentNullException(nameof(warpEngineClass));
            //WeaponSystems = weaponSystems ?? throw new ArgumentNullException(nameof(weaponSystems));
        }

        public Mass Mass { get; set; }
        public IEngineClass ImpulseEngineClass { get; set; }
        public IEngineClass WarpEngineClass { get; set; }
        //public EnergyWeaponClass[] WeaponSystems { get; set; }
    }

    public class Ship
    {
        public Ship(string registration, string name, IShipClass shipClass, Engine impulseEngine, Engine warpEngine)
        {
            Registration = registration ?? throw new ArgumentNullException(nameof(registration));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Class = shipClass ?? throw new ArgumentNullException(nameof(shipClass));
            ImpulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
            WarpEngine = warpEngine ?? throw new ArgumentNullException(nameof(warpEngine));

            
        }

        public IShipClass Class { get; }

        public string Registration { get; set; }
        public string Name { get; set; }

        public Engine ImpulseEngine { get; }
        public Engine WarpEngine { get; }

        public ILocation Location { get; } = new Location();

        //todo: add weapons

        private double _movementEnergyCost = 0.0;
        private Position _newPosition = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns>returns energy cost of the proposed move</returns>
        public double SetCourse(Position position)
        {
            var distance = Location.Position.Distance(position);
            var speed = distance.Speed(TimeSpan.FromSeconds(1));
            _movementEnergyCost = distance.EnergyCost(speed, Class.Mass);
            _newPosition = position;
            return _movementEnergyCost;
        }

        public bool Engage()
        {
            var canMove = ImpulseEngine.FuelSystem.Withdraw(_movementEnergyCost);
            if (canMove)
            {
                Location.Position = _newPosition;
            }
            return canMove;
        }

        /// <summary>
        /// move could be a 2 step event like: SetCourse(), Engage()
        /// where SetCourse would return the energy cost to let the player know the result of his intent
        /// 
        /// impulse to new location in sector
        /// speed is calculated by distance. there's a max speed and therefor a max distance
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private bool Move(Position position)
        {
            var distance = Location.Position.Distance(position);
            var speed = distance.Speed(TimeSpan.FromSeconds(1));
            var energy = distance.EnergyCost(speed, Class.Mass);
            var canMove = ImpulseEngine.FuelSystem.Withdraw(energy);
            if (canMove)
            {
                Location.Position = position;
            }
            return canMove;
        }

        /// <summary>
        /// warp to another sector
        /// speed is calculated by distance. there's a max speed and therefor a max distance.
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        private bool Move(int quadrantId, int[,] sectorId)
        {
            return false;
        }
    }
}
