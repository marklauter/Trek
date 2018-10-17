using System;

namespace Trekish.Models.Ships
{
    public enum EngineTypes
    {
        Impulse,
        Warp
    }

    public interface IEngineClass : IEquipmentClass
    {
        EngineTypes Type { get; set; }
        FuelTypes Fuel { get; }
        IFuelSystemClass FuelSystemClass { get; set; }
    }

    public class EngineClass : EquipmentClass, IEngineClass
    {
        public EngineClass()
        {
        }

        public EngineClass(int techLevel, double efficiency, string name, string description) 
            : base(techLevel, efficiency, name, description)
        {
        }

        public EngineClass(int techLevel, double efficiency, string name, string description, 
            EngineTypes engineType, IFuelSystemClass fuelSystemClass)
            : base(techLevel, efficiency, name, description)
        {
            Type = engineType;
            FuelSystemClass = fuelSystemClass;
        }

        public EngineTypes Type { get; set; }
        public FuelTypes Fuel => Type == EngineTypes.Impulse ? FuelTypes.DeuteriumFusion : FuelTypes.AntiMatter;
        public IFuelSystemClass FuelSystemClass { get; set; }
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
