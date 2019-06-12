using System.Linq;
using DiskraChecker;
using NUnit.Framework;

namespace DiskraCheckerTests
{
    [TestFixture]
    public class TestStraight
    {
        private CoreAssembly _coreAssembly;
        [SetUp]
        public void Setup()
        {
            _coreAssembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5, false);
        }


        [Test]
        public void Straight()
        {
            Assert.AreEqual(10200, _coreAssembly.BruteForcer.GetAmountOfAimCombinations(Combination.Straight));
        }
    }
}