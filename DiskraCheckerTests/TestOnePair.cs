using System.Linq;
using DiskraChecker;
using NUnit.Framework;

namespace DiskraCheckerTests
{
    [TestFixture]
    public class TestOnePair
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void Setup()
        {
            _assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5, false);
        }

        [Test]
        public void OnePairTest()
        {
            Assert.AreEqual(1098240, _assembly.BruteForcer.GetAmountOfAimCombinations(Combination.TwoOfKind));
        }
    }
}