using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Indexers
{
    [TestClass]
    public class Map2DTests
    {
        private IMap2D<int, int, int> pitagoricTable;
        private readonly int[] seven = new int[] { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70 };

        // Called once before each test after the constructor
        [TestInitialize]
        public void TestInitialize()
        {
            pitagoricTable = new Map2D<int, int, int>();
            pitagoricTable.Fill(
                Enumerable.Range(1, 10),
                Enumerable.Range(1, 10),
                (i, j) => i * j
            );
        }

        [TestMethod]
        public void FillAndIndexerTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(i * i, pitagoricTable[i, i]);
            }
        }

        [TestMethod]
        public void GetRowTest()
        {
            if (!pitagoricTable.GetRow(7).Select(t => t.Item2).SequenceEqual(seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }

        [TestMethod]
        public void GetColumnTest()
        {
            if (!pitagoricTable.GetColumn(7).Select(t => t.Item2).SequenceEqual(seven))
            {
                Assert.Fail("Wrong implementation");
            }
        }
    }
}
