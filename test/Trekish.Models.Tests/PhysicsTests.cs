using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trekish.Models.Physics;

namespace Trekish.Models.Test
{
    [TestClass]
    public class PhysicsTests
    {
        [TestMethod]
        public void Distance()
        {
            var p1 = new Position(1, 1);
            var p2 = new Position(2, 2);
            var distance = p1.Distance(p2);
            Assert.AreEqual(DistanceUnits.Kilometer, distance.Units);
            Assert.AreEqual(1.4142, Math.Round(distance.Value, 4));
        }
    }
}
