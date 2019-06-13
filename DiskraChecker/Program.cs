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
          new Card(Suit.Diamonds, Rank.Ace), 
          new Card(Suit.Hearts, Rank.Five), 
          new Card(Suit.Hearts, Rank.King),}, 
        
        new Card[]{new Card(Suit.Spades, Rank.Jack), 
          new Card(Suit.Spades, Rank.Queen), 
          new Card(Suit.Clubs, Rank.Ace),
          new Card(Suit.Clubs, Rank.Five), 
          new Card(Suit.Clubs, Rank.Seven),  }, 7, debug:false);
      //assembly.BruteForcer.SetHandCheckRule(hand => hand.Contains(Combination.TwoOfKind) &&
        //                                            hand.Contains(Combination.Straight) &&
          //                                          !hand.Contains(Combination.ThreeOfKind) &&
            //                                        !hand.Contains(Combination.RoyalFlush));
      //CoreAssembly assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5);
      
      Console.WriteLine(assembly.BruteForcer.GetAmountOfAimCombinations(Combination.TwoOfKind));
    }
  }
}