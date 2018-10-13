using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trekish.Models.Test
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void Galaxy_Ctor()
        {
            var quadrantSize = 3;
            var sectorSize = 10.0;
            var galaxy = new Galaxy(quadrantSize, sectorSize);
            Assert.AreEqual(4, galaxy.Quadrants.Length);

            foreach (var quadrant in galaxy.Quadrants)
            {
                Assert.IsNotNull(quadrant);
                Assert.IsNotNull(quadrant.Sectors);
                Assert.AreEqual(quadrantSize * quadrantSize, quadrant.Sectors.Length);
                for (var i = 0; i < quadrantSize; ++i)
                {
                    for (var j = 0; j < quadrantSize; ++j)
                    {
                        Assert.AreEqual(sectorSize, quadrant.Sectors[i, j].Size);
                        Assert.IsNotNull(quadrant.Sectors[i, j].Objects);
                    }
                }
            }
        }

        [TestMethod]
        public void Engines()
        {

        }
    }
}
