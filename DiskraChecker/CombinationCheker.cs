using System;
using System.Collections.Generic;

namespace DiskraChecker
{

    public enum Combination
    {
        RoyalFlush = 0, StraightFlush, FourOfKind, ThreePlusTwoOfKind, Flush, Straight, ThreeOfKind, TwoPairs, TwoOfKind, None
    }

    public interface ICombinationChecker
    {
        Combination GetMostValuableCombination(CardCollection collection);

        IEnumerable<Combination> GetAllSatisfiedCombinations(CardCollection collection);
        void AddCombinationRule(Combination combination, Func<CardCollection, bool> predicate);
    }
    
    public class CombinationChecker: ICombinationChecker
    {
        private SortedDictionary<Combination, Func<CardCollection, bool>> _combinationsDict;

        public CombinationChecker()
        {
            _combinationsDict = new SortedDictionary<Combination, Func<CardCollection, bool>>();
        }
        public Combination GetMostValuableCombination(CardCollection collection)
        {
            foreach (var el in _combinationsDict)
            {
                if (el.Value(collection))
                {
                    return el.Key;
                }
            }

            return Combination.None;
        }

        public IEnumerable<Combination> GetAllSatisfiedCombinations(CardCollection collection)
        {
            foreach (var el in _combinationsDict)
            {
                if (el.Value(collection))
                {
                    yield return el.Key;
                }
            }

            yield return Combination.None;
        }

        public void AddCombinationRule(Combination combination, Func<CardCollection, bool> predicate)
        {
            _combinationsDict.Add(combination, predicate);
        }
    }
}