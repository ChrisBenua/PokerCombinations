using System.Collections.Generic;

namespace DiskraChecker
{
    public class CoreAssembly
    {
        public BruteForcer BruteForcer { get; }
        public ICombinationChecker CombinationChecker { get; }
        
        public ICombinationRulesProvider CombinationRulesProvider { get; }

        public CoreAssembly(IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int handCards, bool debug)
        {
            CombinationChecker = new CombinationChecker();
            CombinationRulesProvider = new DefaultCombinationRulesProvider();
            
           AddRules();
           if (debug)
           {
               BruteForcer = new DebugBruteForcer(CombinationChecker, hand, forbiddenCards, handCards);
           }
           else
           {
               BruteForcer = new AnswerBruteForcer(CombinationChecker, hand, forbiddenCards, handCards);
           }
        }

        private void AddRules()
        {
            //CombinationChecker.AddCombinationRule(Combination.TwoPairs, CombinationRulesProvider.GetTwoPairsRule());
            //CombinationChecker.AddCombinationRule(Combination.Flush, CombinationRulesProvider.GetFlushRule());
            CombinationChecker.AddCombinationRule(Combination.None, el=> true);
            CombinationChecker.AddCombinationRule(Combination.Straight, CombinationRulesProvider.GetStraightRule());
            //CombinationChecker.AddCombinationRule(Combination.StraightFlush, CombinationRulesProvider.GetStraightFlushRule());
            //CombinationChecker.AddCombinationRule(Combination.FourOfKind, CombinationRulesProvider.GetFourOfKindRule());
            CombinationChecker.AddCombinationRule(Combination.ThreeOfKind, CombinationRulesProvider.GetThreeOfKindRule());
            CombinationChecker.AddCombinationRule(Combination.TwoOfKind, CombinationRulesProvider.GetTwoOfKindRule());
            //CombinationChecker.AddCombinationRule(Combination.ThreePlusTwoOfKind, CombinationRulesProvider.GetThreePlusTwoOfKindRule());
            CombinationChecker.AddCombinationRule(Combination.RoyalFlush, CombinationRulesProvider.GetRoyalFlushRule());
        }
        
        public CoreAssembly(IEnumerable<Card> deck, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int handCards, bool debug)
        {
            CombinationChecker = new CombinationChecker();
            AddRules();
            
            if (debug)
            {
                BruteForcer = new DebugBruteForcer(CombinationChecker,deck, hand, forbiddenCards, handCards);
            }
            else
            {
                BruteForcer = new AnswerBruteForcer(CombinationChecker,deck, hand, forbiddenCards, handCards);
            }
        }
    }
}