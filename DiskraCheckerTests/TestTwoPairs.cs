using System.Linq;
using DiskraChecker;
using NUnit.Framework;

namespace DiskraCheckerTests
{
    [TestFixture]
    public class TestTwoPairs
    {
        private CoreAssembly _assembly;
        
        [SetUp]
        public void Setup()
        {
            _assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 7, false);
        }

        [Test]
        public void TwoPairsTest()
        {
            Assert.AreEqual(123552, _assembly.BruteForcer.GetAmountOfAimCombinations(Combination.TwoPairs));
        }

    }
}