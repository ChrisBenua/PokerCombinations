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



      CoreAssembly assembly = new CoreAssembly(new Card[]{ 
          new Card(Suit.Spades, Rank.Nine), 
          new Card(Suit.Diamonds, Rank.Seven), 
          new Card(Suit.Hearts, Rank.Three),}, 

        new Card[]{new Card(Suit.Spades, Rank.Two), 
          new Card(Suit.Diamonds, Rank.Eight), 
          new Card(Suit.Hearts, Rank.Ace), 
          new Card(Suit.Spades, Rank.Ten), 
          new Card(Suit.Diamonds, Rank.King), }, 7, debug:false);
      //assembly.BruteForcer.SetHandCheckRule(hand => hand.Contains(Combination.TwoOfKind) &&
        //                                          hand.Contains(Combination.Flush) &&
          //                                      !hand.Contains(Combination.ThreeOfKind) &&
            //                                  !hand.Contains(Combination.RoyalFlush));
      //CoreAssembly assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5);

      Console.WriteLine(assembly.BruteForcer.GetAmountOfAimCombinations(Combination.TwoOfKind));

      foreach (var reportItem in assembly.RankDistribuitonCounter.GetDistributionReport())
      {
        Console.WriteLine(reportItem);
      }

    }
  }
}