using System;
using Trekish.Models.Physics;

namespace Trekish.Models
{
    public enum EngineTypes
    {
        Impulse = 0,
        Warp = 1
    }

    public enum FuelTypes
    {
        /// <summary>
        /// fuel source for impluse engines
        /// </summary>
        DeuteriumFusion,
        /// <summary>
        /// fuel source for warp engines
        /// </summary>
        AntiMatter
    }

    public interface IEngineClass : IEquipmentClass
    {
        EngineTypes Type { get; }
        FuelTypes Fuel { get; }
        IFuelSystemClass FuelSystemClass { get; }
        //SpeedFactor MaximumPowerFactor { get; }
    }

    public class EngineClass : IEngineClass
    {
        public EngineClass(string name, double efficiency, int techLevel, EngineTypes engineType, SpeedFactor maxPowerFactor, IFuelSystemClass fuelSystemClass)
        {
            Name = name;
            Efficiency = efficiency;
            TechLevel = techLevel;
            Type = engineType;
            FuelSystemClass = fuelSystemClass;
            MaximumPowerFactor = maxPowerFactor;
        }

        public string Name { get; }
        public double Efficiency { get; }
        public int TechLevel { get; }
        public EngineTypes Type { get; }
        public FuelTypes Fuel => Type == EngineTypes.Impulse ? FuelTypes.DeuteriumFusion : FuelTypes.AntiMatter;
        public IFuelSystemClass FuelSystemClass { get; }
        public SpeedFactor MaximumPowerFactor { get; }
    }

    public interface IFuelSystemClass : IEquipmentClass
    {
        double MaxCapacity { get; }
        FuelTypes Fuel { get; }
    }

    public class FuelSystemClass : IFuelSystemClass
    {
        public FuelSystemClass(double efficiency, int techLevel, string name, double maxCapacity, FuelTypes fuel)
        {
            Efficiency = efficiency;
            TechLevel = techLevel;
            Name = name;
            MaxCapacity = maxCapacity;
            Fuel = fuel;
        }

        public double MaxCapacity { get; }
        public FuelTypes Fuel { get; }
        public double Efficiency { get; }
        public int TechLevel { get; }
        public string Name { get; }
    }

    public class FuelSystem : StorageSystem
    {
        public FuelSystem(IFuelSystemClass fuelSystemClass) : base(fuelSystemClass.MaxCapacity)
        {
            Class = fuelSystemClass ?? throw new ArgumentNullException(nameof(fuelSystemClass));
        }

        public IFuelSystemClass Class { get; }
    }

    public class Engine
    {
        public Engine(IEngineClass engineClass, FuelSystem fuelSystem)
        {
            Class = engineClass ?? throw new ArgumentNullException(nameof(engineClass));
            FuelSystem = fuelSystem ?? throw new ArgumentNullException(nameof(fuelSystem));
            if (FuelSystem.Class.Fuel != Class.Fuel)
            {
                throw new ArgumentException($"Engine type '{Class.Type}' can't run on '{FuelSystem.Class.Fuel}' fuel.");
            }
        }

        public IEngineClass Class { get; set; }
        public FuelSystem FuelSystem { get; }
    }
}
