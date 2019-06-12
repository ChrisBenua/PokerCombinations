using System;
using System.Collections.Generic;
using System.Linq;

namespace DiskraChecker
{
    public interface IBruteForcer
    {
        int GetAmountOfAimCombinations(Combination aim);
    }

    public abstract class BruteForcer : IBruteForcer
    {
        public readonly int CardsFromDeck;
        
        public abstract int GetAmountOfAimCombinations(Combination aim);
        
        protected ICombinationChecker _combinationChecker;
        protected CardCollection _allDeck;
        protected CardCollection _myHand;
        protected CardCollection _forbiddenCards;

        protected BruteForcer()
        {
            _allDeck = new CardCollection();
            _myHand = new CardCollection();
            _forbiddenCards = new CardCollection();
            CardsFromDeck = 7;
        }

        protected BruteForcer(ICombinationChecker checker, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck=7)
        {
            _allDeck = new CardCollection(); _allDeck.FillDefault();
            _myHand = new CardCollection(hand.OrderBy(el => el.Id));
            _forbiddenCards = new CardCollection(forbiddenCards);
            _allDeck.RemoveCardRange(_myHand);
            _allDeck.RemoveCardRange(_forbiddenCards);
            CardsFromDeck = cardsFromDeck;
            _combinationChecker = checker;
        }

        protected BruteForcer(ICombinationChecker checker, IEnumerable<Card> allDeck, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck
        =7)
        {
            _allDeck = new CardCollection(allDeck.OrderBy(el => el.Id));
            _myHand = new CardCollection(hand.OrderBy(el => el.Id));
            _forbiddenCards = new CardCollection(forbiddenCards);
            _allDeck.RemoveCardRange(_myHand);
            _allDeck.RemoveCardRange(_forbiddenCards);
            CardsFromDeck = cardsFromDeck;
            _combinationChecker = checker;
        }

        protected abstract int BruteForce(CardCollection beginHand, CardCollection newHand, CardCollection deck, Combination aim);
    }
    
    public class AnswerBruteForcer: BruteForcer
    {
        private int iterations = 0;

        public AnswerBruteForcer(ICombinationChecker checker, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck=7): base(checker,hand, forbiddenCards, cardsFromDeck)
        {
        }
        
        public AnswerBruteForcer(ICombinationChecker checker, IEnumerable<Card> allDeck, IEnumerable<Card> hand, IEnumerable<Card> forbiddenCards, int cardsFromDeck=7): base(checker,allDeck, hand, forbiddenCards, cardsFromDeck)
        {
        }
        
        public override int GetAmountOfAimCombinations(Combination aim)
        {
            return BruteForce(_myHand, new CardCollection(Enumerable.Empty<Card>()), _allDeck, aim);
        }

        protected override int BruteForce(CardCollection beginHand, CardCollection newHand, CardCollection deck, Combination aim)
        {
            if (newHand.Count() + beginHand.Count() == CardsFromDeck)
            {
                iterations++;
                var myHand = newHand.ToList();
                myHand.AddRange(newHand);
                var cardCol = new CardCollection(myHand);
                if (_combinationChecker.GetMostValuableCombination(cardCol) == aim)
                {
                    //Console.WriteLine(cardCol);
                    return 1;
                }

                return 0;
            }

            int ans = 0;
            var deckCopy = ((CardCollection)deck.Clone()).SkipWhile(el => el.Id < (newHand.LastOrDefault()?.Id ?? -1)).ToList();
            foreach (var card in deckCopy)
            {
                newHand.AddCard(card);

                if (!newHand.SequenceEqual(newHand.OrderBy(el => el.Id)))
                {
                    throw new Exception();
                }
                
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
    }
}