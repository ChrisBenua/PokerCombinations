using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiskraChecker
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      CoreAssembly assembly = new CoreAssembly(new Card[]{new Card(Suit.Hearts, Rank.Two), new Card(Suit.Clubs, Rank.Two), new Card(Suit.Diamonds, Rank.Two),   }, Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 2);
      assembly.CombinationChecker.AddCombinationRule(Combination.TwoOfKind, collection =>
      {
        foreach (var card in collection)
        {
          if (collection.Any(el => el.CardRank == card.CardRank && el.CardSuit != card.CardSuit))
          {
            return true;
          }
        }

        return false;
      });
      Console.WriteLine(assembly.BruteForcer.GetAmountOfAimCombinations(Combination.TwoOfKind));
    }
  }
}