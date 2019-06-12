using System;
using System.Collections.Generic;
using System.Linq;

namespace DiskraChecker
{
    public class DebugBruteForcer:BruteForcer
    {
        private int iterations = 0;
        public override int GetAmountOfAimCombinations(Combination aim)
        {
            return BruteForce(_myHand, _allDeck, aim);
        }

        protected override int BruteForce(CardCollection hand, CardCollection deck, Combination aim)
        {

            if (hand.Count() == CardsFromDeck)
            {
                iterations++;

                if (_combinationChecker.GetAllSatisfiedCombinations(hand).Contains(aim))
                {
                    //Console.WriteLine(hand);
                    return 1;
                }

                return 0;
            }

            int ans = 0;
            var deckCopy = ((CardCollection)deck.Clone()).SkipWhile(el => el.Id < (hand.LastOrDefault()?.Id ?? -1)).ToList();
            foreach (var card in deckCopy)
            {
                hand.AddCard(card);

                if (!hand.SequenceEqual(hand.OrderBy(el => el.Id)))
                {
                    throw new Exception();
                }
                
                deck.RemoveCard(card);
                ans += BruteForce(hand, deck, aim);
                if (iterations % 100000 == 0)
                {
                    Console.WriteLine(iterations);
                }
                hand.RemoveCard(card);
                deck.AddCard(card);
            }

            return ans;
        }

        public DebugBruteForcer(ICombinationChecker checker, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards) : base(checker,hand, forbiddenCards)
        {
        }

        public DebugBruteForcer(ICombinationChecker checker, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck):base(checker,hand, forbiddenCards, cardsFromDeck)
        {
        }
        
        public DebugBruteForcer(ICombinationChecker checker, IEnumerable<Card> allDeck, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck):base(checker,allDeck, hand, forbiddenCards, cardsFromDeck)
        {
        }
    }
}