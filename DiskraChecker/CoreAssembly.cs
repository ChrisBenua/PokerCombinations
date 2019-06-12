using System.Collections.Generic;

namespace DiskraChecker
{
    public class CoreAssembly
    {
        public BruteForcer BruteForcer { get; }
        public ICombinationChecker CombinationChecker { get; }

        public CoreAssembly(IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int handCards)
        {
            CombinationChecker = new CombinationChecker();

            BruteForcer = new DebugBruteForcer(CombinationChecker,hand, forbiddenCards, handCards);
        }
        
        public CoreAssembly(IEnumerable<Card> deck, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int handCards)
        {
            CombinationChecker = new CombinationChecker();

            BruteForcer = new DebugBruteForcer(CombinationChecker,deck, hand, forbiddenCards, handCards);
        }
    }
}