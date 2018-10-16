namespace Trekish.Models.Physics
{
    public enum EnergyUnits
    {
        Undefined,
        Joule,
        KiloJoule,
        MegaJoule,
        GigaJoule,
        TeraJoule
    }

    public class Power : Rate<EnergyUnits>
    {
        public Power()
        {
        }

        public Power(double value) : base(value)
        {
        }

        public Power(double value, EnergyUnits units) : base(value, units)
        {
        }

        public Power(double value, TimeUnits timeUnits) : base(value, timeUnits)
        {
        }

        public Power(double value, EnergyUnits units, TimeUnits timeUnits) : base(value, units, timeUnits)
        {
        }
    }
}
