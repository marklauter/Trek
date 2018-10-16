using System;

namespace Trekish.Models.Ships
{
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

    public interface IFuelSystemClass : IEquipmentClass
    {
        double MaxCapacity { get; set; }
        FuelTypes Fuel { get; set; }
    }

    public class FuelSystemClass : EquipmentClass, IFuelSystemClass
    {
        public FuelSystemClass()
        {
        }

        public FuelSystemClass(int techLevel, double efficiency, string name, string description) 
            : base(techLevel, efficiency, name, description)
        {
        }

        public FuelSystemClass(int techLevel, double efficiency, string name, string description, 
            double maxCapacity, FuelTypes fuel)
            : base(techLevel, efficiency, name, description)
        {
            MaxCapacity = maxCapacity;
            Fuel = fuel;
        }

        public double MaxCapacity { get; set; }
        public FuelTypes Fuel { get; set; }
    }

    public class FuelSystem : StorageSystem
    {
        public FuelSystem(IFuelSystemClass fuelSystemClass) : base(fuelSystemClass.MaxCapacity)
        {
            Class = fuelSystemClass ?? throw new ArgumentNullException(nameof(fuelSystemClass));
        }

        public IFuelSystemClass Class { get; }
    }
}
