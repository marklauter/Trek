﻿namespace Trekish.Models.Ships
{
    public interface IEquipmentClass
    {
        /// <summary>
        /// 1.0 is perfect efficiency which means there are no negative effects applied to equipment operation
        /// </summary>
        int TechLevel { get; set; }
        double Efficiency { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }

    public class EquipmentClass: IEquipmentClass
    {
        public EquipmentClass() { }

        public EquipmentClass(int techLevel, double efficiency, string name, string description)
        {
            TechLevel = techLevel;
            Efficiency = efficiency;
            Name = name;
            Description = description;
        }

        public int TechLevel { get; set; }
        public double Efficiency { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
