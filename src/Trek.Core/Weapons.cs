using System;

namespace Trekish.Models
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Weapons_in_Star_Trek#Subspace_weapons
    /// </summary>
    public enum WeaponTypes
    {
        /// <summary>
        /// directed energy and partical beam weapons: phaser, laser, pulse cannon, plasma cannon, phase cannon, disrupter
        /// </summary>
        Energy,
        ParticalBeam,
        /// <summary>
        /// non-guided projectile: rockets, bullets, arty
        /// </summary>
        Projectile,
        /// <summary>
        /// guided projectile weapons: spatial torpedo, photon (antimatter) torpedo, plasma torpedo, gravimetric torpedo, quantum torpedo, polaron torpedo, phased plasma torpedo
        /// </summary>
        GuidedMissile,
        /// <summary>
        /// disrupts ships traveling at warp
        /// </summary>
        Subspace,
        /// <summary>
        /// disrupts communications
        /// </summary>
        CommJammer,
        /// <summary>
        /// disrupts sensors
        /// </summary>
        SensorJammer,
        /// <summary>
        /// static weapons - can't be seen by long range sensors
        /// </summary>
        Mine
    }

    /// <summary>
    /// directed energy weapons have a max speed of warp 1
    /// subspace weapons have a max speed of warp 10
    /// </summary>    
    public interface IWeaponClass : IEquipmentClass
    {
        string Name { get; set; }
        Rate DamageOutput { get; set; }
        Rate RechargeRate { get; set; }
        Metric MaxRange { get; set; }
    }


    /// <summary>
    /// energy weapons can be fired as a % of full power
    /// for example: 50% power would do 50% damage, but use 50% less drain on battery 
    /// so if you're low on power and need to conserverve, but you're in the fight for your life...
    /// </summary>
    public class EnergyWeaponClass : IWeaponClass
    {
        public Metric EnergyCost { get; set; }
        public string Name { get; set; }
        public Rate DamageOutput { get; set; }
        public Rate RechargeRate { get; set; }
        public Metric MaxRange { get; set; }
        public double Efficiency { get; set; }
        public int TechLevel { get; set; }
    }

    public class ProjectileWeaponClass : IWeaponClass
    {
        /// <summary>
        /// guided weapons don't have to be aimed as precisely as non-guided weapons
        /// </summary>
        public bool Guided { get; set; }

        private Speed _velocity = (Speed)0.0;
        public Speed Velocity
        {
            get => _velocity;
            set
            {
                if (value.Value < 1.0)
                {
                    _velocity = value;
                }
            }
        }

        public int CapacityPerUnit { get; set; }
        public string Name { get; set; }
        public Rate DamageOutput { get; set; }
        public Rate RechargeRate { get; set; }
        public Metric MaxRange { get; set; }
        public double Efficiency { get; set; }
        public int TechLevel { get; set; }
    }

    public interface IWeaponStore<WC> where WC : IWeaponClass
    {
        WC WeaponClass { get; }
        bool AddCapacity();
        bool RemoveCapacity();
        /// <summary>
        /// energy weapons have infinate capacity and charge off the battery
        /// projectile/missile weapons must be taken from ship weapon stores inventory
        /// </summary>
        int MaxCapacity { get; set; }
        int CapacityUsed { get; }
    }

    public class AmmoStore : IWeaponStore<ProjectileWeaponClass>
    {
        public AmmoStore(ProjectileWeaponClass weaponClass)
        {
            WeaponClass = weaponClass ?? throw new ArgumentNullException(nameof(weaponClass));
        }

        private int _inventory = 0;

        public ProjectileWeaponClass WeaponClass { get; set; }

        public bool AddCapacity()
        {
            if (CapacityUsed + WeaponClass.CapacityPerUnit <= MaxCapacity)
            {
                ++_inventory;
                CapacityUsed += WeaponClass.CapacityPerUnit;
                return true;
            }
            return false;
        }

        public bool RemoveCapacity()
        {
            if (_inventory > 0)
            {
                --_inventory;
                CapacityUsed -= WeaponClass.CapacityPerUnit;
                return true;
            }
            return false;
        }

        public int MaxCapacity { get; set; }
        public int CapacityUsed { get; private set; }
    }

    public class Target
    {
        public SpeedFactor Velocity { get; set; }
        public Metric Distance { get; set; }
        public double Vector { get; set; }
    }

    public class Weapon<WC> where WC : IWeaponClass
    {
        public WC Class { get; set; }
        public bool Ready { get; set; }
        public IWeaponStore<WC> WeaponStore { get; set; }

        /// <summary>
        /// uses weapon type, target properties such as shield, distance, speed to calculate % likely to hit and damage output to be assigned to target
        /// </summary>
        /// <returns>damage output</returns>
        public double Discharge(Target target)
        {
            if (WeaponStore.RemoveCapacity())
            {
                //todo: calculate hit & damage
            }
            //todo: set timer for ready state change
            return 0.0;
        }
    }
}
