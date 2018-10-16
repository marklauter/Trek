using System;
using System.Collections.Generic;
using System.Text;

namespace Trekish.Models.Physics
{
    public enum MassUnits
    {
        Undefined,
        Grams,
        Kilograms,
    }

    public class Mass : Metric<MassUnits>
    {
        public Mass()
        {
            Units = MassUnits.Kilograms;
        }

        public Mass(double value) : base(value)
        {
            Units = MassUnits.Kilograms;
        }

        public Mass(double value, MassUnits units) : base(value, units)
        {
        }

        public static explicit operator Mass(double value)
        {
            return new Mass(value, MassUnits.Undefined);
        }

        public static explicit operator double(Mass metric)
        {
            return metric.Value;
        }
    }
}
