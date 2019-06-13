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

      
      
        CoreAssembly assembly = new CoreAssembly(new Card[]{new Card(Suit.Clubs, Rank.Three), 
          new Card(Suit.Hearts, Rank.Three), 
          new Card(Suit.Hearts, Rank.Eight),}, 
        
        new Card[]{new Card(Suit.Hearts, Rank.Ace),
          new Card(Suit.Spades, Rank.Four), 
          new Card(Suit.Spades, Rank.Five), 
          new Card(Suit.Clubs, Rank.Four), 
          new Card(Suit.Clubs, Rank.Queen),  }, 7, debug:false);
      //CoreAssembly assembly = new CoreAssembly(Enumerable.Empty<Card>(), Enumerable.Empty<Card>(), 5);
      
      Console.WriteLine(assembly.BruteForcer.GetAmountOfAimCombinations(Combination.TwoPairs));
    }
  }
}