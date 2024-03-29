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
            return BruteForce(_myHand, new CardCollection(Enumerable.Empty<Card>()), _allDeck, aim);
        }

        protected override int BruteForce(CardCollection beginHand, CardCollection newHand, CardCollection deck, Combination aim)
        {

            if (beginHand.Count() + newHand.Count() == CardsFromDeck)
            {
                iterations++;
                
                var myHand = newHand.ToList();
                myHand.AddRange(beginHand);
                var cardCol = new CardCollection(myHand);
                if (_myHandCheckRule is null)
                {
                    if (_combinationChecker.GetAllSatisfiedCombinations(cardCol).Contains(aim))
                    {
                        _rankDistribuitonCounter.AddToDistribution(cardCol);
                        //Console.WriteLine(cardCol);
                        return 1;
                    }
                }
                else
                {
                    if (_myHandCheckRule.Invoke(_combinationChecker.GetAllSatisfiedCombinations(cardCol)))
                    {
                        _rankDistribuitonCounter.AddToDistribution(cardCol);
                        //Console.WriteLine(cardCol);
                        return 1;
                    }
                }

                return 0;
            }

            int ans = 0;
            var deckCopy = ((CardCollection)deck.Clone()).SkipWhile(el => el.Id < (newHand.LastOrDefault()?.Id ?? -1)).ToList();
            foreach (var card in deckCopy)
            {
                newHand.AddCard(card);

                deck.RemoveCard(card);
                ans += BruteForce(beginHand, newHand, deck, aim);
                if (iterations % 100000 == 0)
                {
                    Console.WriteLine(iterations);
                }
                newHand.RemoveCard(card);
                deck.AddCard(card);
            }

            return ans;
        }

        public DebugBruteForcer(IRankDistribuitonCounter rankDistribuitonCounter, ICombinationChecker checker, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards) : base(rankDistribuitonCounter,checker,hand, forbiddenCards)
        {
        }

        public DebugBruteForcer(IRankDistribuitonCounter rankDistribuitonCounter, ICombinationChecker checker, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck):base(rankDistribuitonCounter,checker,hand, forbiddenCards, cardsFromDeck)
        {
        }
        
        public DebugBruteForcer(IRankDistribuitonCounter rankDistribuitonCounter, ICombinationChecker checker, IEnumerable<Card> allDeck, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck):base(rankDistribuitonCounter,checker,allDeck, hand, forbiddenCards, cardsFromDeck)
        {
        }
    }
}