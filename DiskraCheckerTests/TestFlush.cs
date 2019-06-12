using System.Linq;
using DiskraChecker;
using NUnit.Framework;

namespace DiskraCheckerTests
{
    [TestFixture]
    public class TestFlush
    {
        private CoreAssembly _assembly;
        
        [SetUp]
        public void Setup()
        {
            _assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5, false);
        }

        [Test]
        public void TestAmountOfFlushes()
        {
            Assert.AreEqual(5108,_assembly.BruteForcer.GetAmountOfAimCombinations(Combination.Flush));
        }
    }
}