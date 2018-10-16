using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trekish.Models.Ships;

namespace Trekish.Models.Test
{
    [TestClass]
    public class ShipTests
    {
        private static FuelSystemClass GetFuelSystemClass(EngineTypes engineType)
        {
            var techLevel = 1;
            var efficiency = 1.0;

            return new FuelSystemClass(
                techLevel,
                efficiency,
                "",
                "",
                1000000,
                engineType == EngineTypes.Impulse
                    ? FuelTypes.DeuteriumFusion
                    : FuelTypes.AntiMatter);
        }

        private static IEngineClass GetEngineClass(EngineTypes engineType)
        {
            var techLevel = 1;
            var efficiency = 1.0;

            return new EngineClass(
                techLevel,
                efficiency,
                "",
                "",
                engineType,
                GetFuelSystemClass(engineType));
        }

        private static IShipClass GetShipClass()
        {
            var techLevel = 1;
            var efficiency = 1.0;

            return new ShipClass(
                techLevel,
                efficiency,
                "NX",
                "United Earth Starfleet Flagship",
                new Physics.Mass(5, Physics.MassUnits.Kilograms),
                GetEngineClass(EngineTypes.Impulse),
                GetEngineClass(EngineTypes.Warp));
        }

        [TestMethod]
        public void ShipTest_Ctor()
        {
            var shipClass = GetShipClass();
            var impulseEngine = new Engine(GetEngineClass(EngineTypes.Impulse), new FuelSystem(GetFuelSystemClass(EngineTypes.Impulse)));
            var warpEngine = new Engine(GetEngineClass(EngineTypes.Warp), new FuelSystem(GetFuelSystemClass(EngineTypes.Warp)));
            var ship = new Ship("NX-01", "Enterprise", shipClass, impulseEngine, warpEngine);
        }

        [TestMethod]
        public void ShipTest_Location()
        {
            var shipClass = GetShipClass();
            var impulseEngine = new Engine(GetEngineClass(EngineTypes.Impulse), new FuelSystem(GetFuelSystemClass(EngineTypes.Impulse)));
            var warpEngine = new Engine(GetEngineClass(EngineTypes.Warp), new FuelSystem(GetFuelSystemClass(EngineTypes.Warp)));
            var ship = new Ship("NX-01", "Enterprise", shipClass, impulseEngine, warpEngine);

            ship.Location.SectorSize = 100;
            Assert.AreEqual(0.0, ship.Location.Position.X);
            Assert.AreEqual(0.0, ship.Location.Position.Y);
        }

        [TestMethod]
        public void ShipTest_SetCourse()
        {
            var shipClass = GetShipClass();
            var impulseEngine = new Engine(GetEngineClass(EngineTypes.Impulse), new FuelSystem(GetFuelSystemClass(EngineTypes.Impulse)));
            var warpEngine = new Engine(GetEngineClass(EngineTypes.Warp), new FuelSystem(GetFuelSystemClass(EngineTypes.Warp)));
            var ship = new Ship("NX-01", "Enterprise", shipClass, impulseEngine, warpEngine);

            ship.Location.SectorSize = 100;
            Assert.AreEqual(0.0, ship.Location.Position.X);
            Assert.AreEqual(0.0, ship.Location.Position.Y);

            var energy = ship.SetCourse(new Physics.Position(5,5));
            Assert.AreEqual(250.0, Math.Round(energy, 0));
        }

        [TestMethod]
        public void ShipTest_SetCourse_Engage()
        {
            var shipClass = GetShipClass();
            var impulseEngine = new Engine(GetEngineClass(EngineTypes.Impulse), new FuelSystem(GetFuelSystemClass(EngineTypes.Impulse)));
            var warpEngine = new Engine(GetEngineClass(EngineTypes.Warp), new FuelSystem(GetFuelSystemClass(EngineTypes.Warp)));
            var ship = new Ship("NX-01", "Enterprise", shipClass, impulseEngine, warpEngine);
            ship.ImpulseEngine.FuelSystem.Deposit(1000);

            ship.Location.SectorSize = 100;
            Assert.AreEqual(0.0, ship.Location.Position.X);
            Assert.AreEqual(0.0, ship.Location.Position.Y);

            var position = new Physics.Position(5, 5);
            var energy = ship.SetCourse(position);
            Assert.AreEqual(250.0, Math.Round(energy, 0));

            var success = ship.Engage();
            Assert.IsTrue(success);

            Assert.AreEqual(position, ship.Location.Position);

            Assert.AreEqual(750, Math.Round(ship.ImpulseEngine.FuelSystem.Balance,0));
        }

    }
}
