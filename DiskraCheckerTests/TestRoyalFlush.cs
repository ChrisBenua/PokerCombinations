using System.Linq;
using DiskraChecker;
using NUnit.Framework;

namespace DiskraCheckerTests
{
    [TestFixture]
    public class TestRoyalFlush
    {
        private CoreAssembly _assembly;
        
        [SetUp]
        public void Setup()
        {
            _assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5, false);
        }

        [Test]
        public void RoyalFlush()
        {
            Assert.AreEqual(4, _assembly.BruteForcer.GetAmountOfAimCombinations(Combination.RoyalFlush));
        }
    }
}