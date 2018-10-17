namespace Trekish.Models.Ships
{
    public interface IShieldClass : IEquipmentClass
    {

    }

    public class ShieldClass : EquipmentClass, IShieldClass
    {
        public ShieldClass()
        {
        }

        public ShieldClass(int techLevel, double efficiency, string name, string description) : base(techLevel, efficiency, name, description)
        {
        }

        ///// <summary>
        ///// different shield classes are better at absorbing damage from different weapon types
        ///// </summary>
        //public Dictionary<WeaponClass, Rate> DamageAbsorbtionRate { get; set; }

        ///// <summary>
        ///// rate of energy disipation, or demand on the ship's batteries, during engagement with a particular weapon type 
        ///// </summary>
        //public Dictionary<WeaponClass, Rate> EnergyDemand { get; set; }
    }

    public class Shield
    {
        public IShieldClass Class { get; }
    }
}
